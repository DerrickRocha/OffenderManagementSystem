namespace OffenderManagementSystem.models;

public class Offender
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Crime { get; set; }
    public DateTime SentenceStart { get; set; }
    public DateTime SentenceEnd { get; set; }
}