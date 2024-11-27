namespace Up.DataAccess.Entities;

public class Address
{
    public int AddressId { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required string PostalCode { get; set; }
}
