[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Faculties()
    {
        var faculties = _context.Faculties.ToList();
        return View(faculties);
    }

    [HttpPost]
    public IActionResult AddFaculty(string name, string department)
    {
        var faculty = new Faculty { Name = name, Department = department };
        _context.Faculties.Add(faculty);
        _context.SaveChanges();
        return RedirectToAction("Faculties");
    }
}
