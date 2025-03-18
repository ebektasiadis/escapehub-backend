namespace Domain.User;

public sealed class User
{
    public UserId Id { get; private set; }
    public string IdentityProviderId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    private User() { }

    private User(UserId id, string identityProviderId, string firstName, string lastName, string email, string password)
    {
        Id = id;
        IdentityProviderId = identityProviderId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string identityProviderId, string firstName, string lastName, string email, string password)
    {
        UserId userId = new UserId(new Ulid());
        return new User(userId, identityProviderId, firstName, lastName, email, password);
    }
}
