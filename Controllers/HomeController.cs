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

        public ActionResult Index(int? sortOrder)
        {

            var cars = _context.Cars.Include(m => m.Type).ToList();

            switch (sortOrder)
            {
                case 1:
                    cars = _context.Cars.Where(m => m.TypeId == 1).Include(m => m.Type).ToList();
                    break;
                case 2:
                    cars = _context.Cars.Where(m => m.TypeId == 2).Include(m => m.Type).ToList();
                    break;
                case 3:
                    cars = _context.Cars.Where(m => m.TypeId == 3).Include(m => m.Type).ToList();
                    break;
                case 4:
                    cars = _context.Cars.Where(m => m.TypeId == 4).Include(m => m.Type).ToList();
                    break;
                case 5:
                    cars = _context.Cars.Where(m => m.TypeId == 5).Include(m => m.Type).ToList();
                    break;
                case 6:
                    cars = _context.Cars.Where(m => m.TypeId == 6).Include(m => m.Type).ToList();
                    break;
            }

            return View(cars);
        }


        [HttpGet]
        [Authorize]
        public ActionResult Rent(int id, DateTime dateRented, DateTime dateReturned)
        {
            if (dateRented.Date < DateTime.Now.Date || dateReturned.Date < dateRented.Date || dateReturned.Date < DateTime.Now)
            {
                return RedirectToAction("Index", "Home");
            }

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
                DateRented = dateRented,
                DateReturned = dateReturned,
                TotalPrice = (cars.Price) * (dateReturned - dateRented).Days
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
                DateReturned = model.DateReturned,
                TotalPrice = model.TotalPrice


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