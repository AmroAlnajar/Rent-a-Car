using Microsoft.AspNet.Identity;
using Rent_a_Car.Helpers;
using Rent_a_Car.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Rent_a_Car.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var cars = _context.Cars.Include(m => m.Type).ToList();

            return View(cars);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Rent(int id, int daystorent)
        {
            Helper helper = new Helper();

            var cars = _context.Cars.Find(id);
            var useremail = User.Identity.Name;
            var username = helper.GetName(User.Identity.GetUserId());

            var viewmodel = new RentalViewModel
            {
                UserName = username,
                UserEmail = useremail,
                CarMake = cars.Make,
                CarMod = cars.Mod,
                CarPicture = cars.Picture,
                CarPrice = cars.Price,
                CarId = cars.Id,
                CustomerId = User.Identity.GetUserId(),
                DateRented = DateTime.Now,
                DaysToRent = daystorent
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult RentPost(RentalViewModel model)
        {

            var rentals = new Rental
            {
                CarId = model.CarId,
                CustomerId = model.CustomerId,
                DateRented = model.DateRented,
                DateReturned = model.DateRented.AddDays(model.DaysToRent)


            };

            _context.Rentals.Add(rentals);

            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}