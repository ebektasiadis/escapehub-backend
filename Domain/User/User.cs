namespace Domain.User;

public sealed class User
{
    public UserId Id { get; private set; }
    public string IdentityProviderId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private User() { }
}