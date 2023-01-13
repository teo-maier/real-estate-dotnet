using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReastEstateWebApp.Models;

public class Property
{
    public int Id { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$",
        ErrorMessage = "Numele proprietatii trebuie sa inceapa cu majuscula " +
                       "(ex. Ana sau Ana Maria sau AnaMaria")]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(200)] public string Description { get; set; }
    public float Price { get; set; }
    [StringLength(20)] public PropertyStatus? PropertyStatus { get; set; }

    public int AgentId { get; set; }

    public Agent? Agent { get; set; }

    public Sale? Sale { get; set; }

    public string? ImageData { get; set; }
    [NotMapped] public IFormFile ImageFile { get; set; }
}