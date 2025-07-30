public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<FacultySelection> FacultySelections { get; set; }
}
