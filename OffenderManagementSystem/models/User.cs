namespace OffenderManagementSystem.models;

public class User
{
    public int Id { set; get; }
    public string? Username { set; get; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    
    // Navigation properties
    public ICollection<Offender> Offenders { get; set; }
    public ICollection<Report> Reports { get; set; }
}
