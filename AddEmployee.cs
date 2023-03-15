using PayrollApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PayrollApp.Controllers
{
    public class AddEmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddEmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var admins = await _context.Admin.ToListAsync();

            return View(admins);
        }
    }
}
