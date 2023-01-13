using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReastEstateWebApp.Data;
using ReastEstateWebApp.Models;

namespace ReastEstateWebApp.Pages.Properties
{
    public class EditModel : PageModel
    {
        private readonly ReastEstateWebApp.Data.ReastEstateWebAppContext _context;

        public EditModel(ReastEstateWebApp.Data.ReastEstateWebAppContext context)
        {
            _context = context;
        }

        [BindProperty] public Property Property { get; set; } = default!;
        [BindProperty] public PropertyStatus PropertyStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var property = await _context.Property.FirstOrDefaultAsync(m => m.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            var agentList = _context.Agent.Select(x => new
            {
                x.Id,
                Name = x.Name
            });

            List<string> propertyTypeStatusList = new List<string>();
            foreach (var value in Enum.GetValues(typeof(PropertyTypeStatus)))
            {
                var propertyStatus = ((PropertyTypeStatus)value).ToString();
                propertyTypeStatusList.Add(propertyStatus);
            }

            ViewData["Id"] = new SelectList(agentList, "Id", "Name");
            ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "Name");
            ViewData["PropertyStatus"] = new SelectList(propertyTypeStatusList);

            Property = property;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyToUpdate = await _context.Property
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            var propertyStatusTypeToUpdate = await _context.PropertyStatus
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PropertyId == id);

            if (propertyToUpdate == null || propertyStatusTypeToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Property).State = EntityState.Modified;

            if (await TryUpdateModelAsync<Property>(
                    propertyToUpdate,
                    "Property",
                    i => i.Name, i => i.Description,
                    i => i.Price, i => i.Agent))
            {
                await _context.SaveChangesAsync();

                await TryUpdateModelAsync<PropertyStatus>(
                    propertyStatusTypeToUpdate,
                    "PropertyStatus",
                    i => i.PropertyType
                );

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PropertyExists(int id)
        {
            return (_context.Property?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}