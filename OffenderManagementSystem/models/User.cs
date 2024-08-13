namespace OffenderManagementSystem.models;

public class User
{
    public int Id { set; get; }
    public string? Username { set; get; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}
