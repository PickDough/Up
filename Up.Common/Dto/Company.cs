namespace Up.DataAccess.Entities;

public class Company
{
    public int CompanyId { get; set; }
    public required string CompanyName { get; set; }
    public required string CompanyInfo { get; set; }
}
