namespace OffenderManagementSystem.models;

public class Report
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
    
    // Foreign keys
    public int OffenderId { get; set; }
    public int UserId { get; set; }

    // Navigation properties
    public Offender Offender { get; set; }
    public User User { get; set; }
}