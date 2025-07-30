[Authorize(Roles = "Student")]
public class SelectionController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SelectionController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var faculties = _context.Faculties.ToList();
        return View(faculties);
    }

    [HttpPost]
    public IActionResult Submit(List<int> selectedFaculties)
    {
        var studentId = _userManager.GetUserId(User);

        foreach (var id in selectedFaculties)
        {
            var selection = new FacultySelection
            {
                StudentId = studentId,
                FacultyId = id
            };
            _context.FacultySelections.Add(selection);
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
