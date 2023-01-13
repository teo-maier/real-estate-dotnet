using System.ComponentModel.DataAnnotations;

namespace ReastEstateWebApp.Models;

public class Client
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    [RegularExpression(@"^\(?([0][0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
        ErrorMessage = "Telefonul  trebuie sa fie de forma '0722-123-123' " +
                       "sau '0722.123.123' sau '0722 123 123'")]
    public string? PhoneNumber { get; set; }

    public string? Address;

    public Sale? Sale;
}