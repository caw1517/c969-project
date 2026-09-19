namespace C969_Project.Database;

public class AppointmentConflict
{
    public int AppointmentId { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }
}