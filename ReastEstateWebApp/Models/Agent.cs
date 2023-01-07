using System.ComponentModel.DataAnnotations;

namespace ReastEstateWebApp.Models;

public class Agent
{
    public int Id { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$",
        ErrorMessage = "Numele proprietatii trebuie sa inceapa cu majuscula " +
                       "(ex. Ana sau Ana Maria sau AnaMaria")]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }

    [RegularExpression(@"^\(?([0][0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
        ErrorMessage = "Telefonul  trebuie sa fie de forma '0722-123-123' " +
                       "sau '0722.123.123' sau '0722 123 123'")]
    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }
    public string? Address { get; set; }
}