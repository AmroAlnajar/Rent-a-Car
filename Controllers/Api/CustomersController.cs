using Rent_a_Car.Models;
using System.Linq;
using System.Web.Http;

namespace Rent_a_Car.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetCustomers()
        {

            var customers = _context.Users.ToList();

            return Ok(customers);
        }
    }
}
