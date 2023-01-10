using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReastEstateWebApp.Data;
using ReastEstateWebApp.Models;

namespace ReastEstateWebApp.Pages.Properties
{
    public class CreateModel : PageModel
    {
        private readonly ReastEstateWebApp.Data.ReastEstateWebAppContext _context;

        public CreateModel(ReastEstateWebApp.Data.ReastEstateWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (_context.Agent == null)
            {
                throw new NotSupportedException("no agents");
            }
            var agentList = _context.Agent.Select(x => new
            {
                x.Id,
                Name = x.Name
            });
            ViewData["AgentId"] = new SelectList(agentList, "Id", "Name");
            return Page();
        }

        [BindProperty] public Property Property { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            var newProperty = new Property();
            if (!ModelState.IsValid || _context.Property == null || Property == null)
            {
                return Page();
            }

            if (await TryUpdateModelAsync<Property>(
                    newProperty,
                    "Property",
                    i => i.Name,
                    i => i.AgentId,
                    i => i.Price,
                    i => i.PropertyStatus,
                    i => i.Description
                ))
            {
                _context.Property.Add(newProperty);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}