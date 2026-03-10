namespace SecurityDemo.Models;

public class SecretNote
{
    public int Id { get; set; }
    public string OwnerId { get; set; }
    public string Content { get; set; }
}
public enum Role
{
    User = 0,
    Admin = 1
}

public class UserProfile
{
    public int Id {get;set;}
    public string Name {get;set;}
    public string password {get;set;}
    public Role userRole {get;set;}
}