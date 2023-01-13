namespace ReastEstateWebApp.Models;

public enum PropertyTypeStatus
{
    Active,
    Pending,
    Sold
}

public class PropertyStatus
{
    public int Id { get; set; }
    public string PropertyType { get; set; }
    public int PropertyId { get; set; }
    public Property? Property { get; set; }
}