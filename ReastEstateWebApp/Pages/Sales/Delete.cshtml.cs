using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReastEstateWebApp.Data;
using ReastEstateWebApp.Models;

namespace ReastEstateWebApp.Pages.Sales
{
    public class DeleteModel : PageModel
    {
        private readonly ReastEstateWebApp.Data.ReastEstateWebAppContext _context;

        public DeleteModel(ReastEstateWebApp.Data.ReastEstateWebAppContext context)
        {
            _context = context;
        }

        [BindProperty] public Sale Sale { get; set; } = default!;
        public Agent Agent { get; set; } = default!;
        public Client Client { get; set; } = default!;
        public Property Property { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FirstOrDefaultAsync(m => m.Id == id);
            var agent = await _context.Agent.FirstOrDefaultAsync(m => m.Id == sale.AgentId);
            var client = await _context.Client.FirstOrDefaultAsync(m => m.Id == sale.ClientId);
            var property = await _context.Property.FirstOrDefaultAsync(m => m.Id == sale.PropertyId);

            if (sale == null)
            {
                return NotFound();
            }
            else
            {
                Sale = sale;
                Agent = agent;
                Client = client;
                Property = property;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);

            if (sale != null)
            {
                Sale = sale;
                _context.Sale.Remove(Sale);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}