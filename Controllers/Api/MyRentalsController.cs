using Microsoft.AspNet.Identity;
using Rent_a_Car.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Rent_a_Car.Controllers.Api
{

    public class MyRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MyRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public IHttpActionResult GetMyOrders()
        {
            var userid = User.Identity.GetUserId();

            var orders = _context.Rentals.Include(m => m.Car).Where(m => m.CustomerId == userid).ToList();


            return Ok(orders);
        }
    }
}
