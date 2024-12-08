namespace Builder.Entity;

public class User
{
    public int UserId { get; set; }
    public DateTime RegistrationDate { get; private init; } = DateTime.UtcNow;
    public string Email { get; set; }
}