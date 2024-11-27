namespace Up.DataAccess.Entities;

public class Position
{
    public int PositionId { get; set; }
    public required string PositionName { get; set; }
    public required decimal Salary { get; set; }
}
