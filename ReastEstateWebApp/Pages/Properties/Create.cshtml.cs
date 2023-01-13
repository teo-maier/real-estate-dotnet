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

            List<string> propertyTypeStatusList = new List<string>();
            foreach (var value in Enum.GetValues(typeof(PropertyTypeStatus)))
            {
                var propertyStatus = ((PropertyTypeStatus)value).ToString();
                propertyTypeStatusList.Add(propertyStatus);
            }

            // var a = _context.PropertyStatus.Select(x => new
            // {
            //     x.Id,
            //     PropertyType = x.PropertyType
            // });


            ViewData["AgentId"] = new SelectList(agentList, "Id", "Name");
            ViewData["PropertyStatus"] = new SelectList(propertyTypeStatusList);

            return Page();
        }

        [BindProperty] public Property Property { get; set; } = default!;
        [BindProperty] public PropertyStatus PropertyStatus { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            var newProperty = new Property();
            var newPropertyStatus = new PropertyStatus();
            byte[] bytes = null;

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
                    i => i.Description,
                    i => i.ImageFile
                ))
            {
                if (Property.ImageFile != null)
                {
                    using (Stream fs = Property.ImageFile.OpenReadStream())
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                        }
                    }
                    newProperty.ImageData = Convert.ToBase64String(bytes, 0, bytes.Length);
                }
                
                _context.Property.Add(newProperty);
                await _context.SaveChangesAsync();
                
                newPropertyStatus.PropertyId = newProperty.Id;
                await TryUpdateModelAsync<PropertyStatus>(
                    newPropertyStatus,
                    "PropertyStatus",
                    i => i.PropertyType
                );
                
                // add image file

                

                _context.PropertyStatus.Add(newPropertyStatus);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Properties/Index");
            }

            return Page();
        }
    }
}