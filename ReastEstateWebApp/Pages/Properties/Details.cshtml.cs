using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReastEstateWebApp.Data;
using ReastEstateWebApp.Models;

namespace ReastEstateWebApp.Pages.Properties
{
    public class DetailsModel : PageModel
    {
        private readonly ReastEstateWebApp.Data.ReastEstateWebAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(ReastEstateWebApp.Data.ReastEstateWebAppContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Property Property { get; set; } = default!;
        public PropertyStatus PropertyStatus { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var property = await _context.Property.FirstOrDefaultAsync(m => m.Id == id);
            var propertyStatus = await _context.PropertyStatus.FirstOrDefaultAsync(m => m.PropertyId == id);

            if (property == null || propertyStatus == null)
            {
                return NotFound();
            }
            else
            {
                Property = property;
                PropertyStatus = propertyStatus;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var newSale = new Sale();

            if (!ModelState.IsValid || _context.Property == null || _context.Agent == null || _context.Client == null)
            {
                return Page();
            }

            var currentProperty = await _context.Property
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            
            var user = _userManager.FindByNameAsync(User.Identity.Name);

            var getClient = await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == user.Id);

            newSale.PropertyId = currentProperty.Id;
            newSale.AgentId = currentProperty.AgentId;
            newSale.ClientId = getClient.Id;
            
            // set property status to pending after sale is made
            // if property status is pending or sold -> hide 'request' button
            
            _context.Sale.Add(newSale);
            
            var propertyStatus = await _context.PropertyStatus
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PropertyId == id);
            
            propertyStatus.PropertyType = "Pending";
            _context.PropertyStatus.Update(propertyStatus);

            await _context.SaveChangesAsync();
            return RedirectToPage("/Properties/UserIndex");
        }
    }
}