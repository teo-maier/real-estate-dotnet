// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using ReastEstateWebApp.Models;
// using Property = Microsoft.EntityFrameworkCore.Metadata.Internal.Property;
//
// namespace ReastEstateWebApp.Pages.Properties
// {
//     public class UserIndexModel : PageModel
//     {
//         private readonly ReastEstateWebApp.Data.ReastEstateWebAppContext _context;
//
//         public UserIndexModel(ReastEstateWebApp.Data.ReastEstateWebAppContext context)
//         {
//             _context = context;
//         }
//
//         public IList<Property> Property { get; set; } = default!;
//         public IList<PropertyStatus> PropertyStatus { get; set; } = default!;
//
//         public async Task OnGetAsync()
//         {
//             if (_context.Property != null)
//             {
//                 Property = await _context.Property.ToListAsync();
//                 PropertyStatus = await _context.PropertyStatus.ToListAsync();
//                 foreach (var i in Property)
//                 {
//                     var status = _context.PropertyStatus
//                         .Where(b => b.PropertyId == i.Id)
//                         .FirstOrDefault();
//                     i.PropertyStatus = status;
//                 }
//             }
//         }
//     }
// }