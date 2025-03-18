namespace SharedKernel;

public record Error(string Code, string Message)
{

    public static readonly Error None = new("None", string.Empty);
    public static readonly Error Generic = new("Generic", "An error occurred");

    public string Code { get; }
    public string Message { get; }
}
