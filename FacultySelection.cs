public class FacultySelection
{
    public int Id { get; set; }

    public string StudentId { get; set; }
    public IdentityUser Student { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}
