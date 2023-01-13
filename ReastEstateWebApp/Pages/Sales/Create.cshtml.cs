using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReastEstateWebApp.Data;
using ReastEstateWebApp.Models;

namespace ReastEstateWebApp.Pages.Sales
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
        ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "Id");
        ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id");
        ViewData["PropertyId"] = new SelectList(_context.Property, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sale == null || Sale == null)
            {
                return Page();
            }

            _context.Sale.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
