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
    public class IndexModel : PageModel
    {
        private readonly ReastEstateWebApp.Data.ReastEstateWebAppContext _context;

        public IndexModel(ReastEstateWebApp.Data.ReastEstateWebAppContext context)
        {
            _context = context;
        }

        public IList<Sale> Sale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sale != null)
            {
                Sale = await _context.Sale
                .Include(s => s.Agent)
                .Include(s => s.Client)
                .Include(s => s.Property).ToListAsync();
            }
        }
    }
}
