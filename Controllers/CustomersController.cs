using Rent_a_Car.Models;
using System.Linq;
using System.Web.Mvc;

namespace Rent_a_Car.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var users = _context.Users.ToList();

            return View(users);
        }
    }
}