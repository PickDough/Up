namespace Up.Core.Exceptions;

public class InvalidOperationCoreException<T>: InvalidOperationException
{
    public required T Value { get; init; }
    public required string Operation { get; init; }
    public override string ToString() => $"Failed to {Operation} {Value}";
}
