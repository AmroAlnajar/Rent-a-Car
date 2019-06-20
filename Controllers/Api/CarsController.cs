using Rent_a_Car.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;


namespace Rent_a_Car.Controllers.Api
{

    public class CarsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]

        public IHttpActionResult GetCars()
        {

            var cars = _context.Cars.Include(c => c.Type).ToList();



            return Ok(cars);
        }

        [HttpGet]
        public IHttpActionResult GetCar(int id)
        {


            var cars = _context.Cars.Include(c => c.Type).SingleOrDefault(c => c.Id == id);

            if (cars == null)
            {
                return NotFound();
            }


            return Ok(cars);
        }

        [HttpPost]
        public IHttpActionResult AddCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Something went wrong. Are you use you have all the correct parameters?");
                throw;
            }


            return Ok("Car added. New Id: " + car.Id);
        }


        [HttpPut]
        public IHttpActionResult EditCar(int id, Car car)
        {

            var carInDb = _context.Cars.Single(c => c.Id == id);

            carInDb.Make = car.Make;
            carInDb.Mod = car.Mod;
            carInDb.Price = car.Price;
            carInDb.Picture = car.Picture;
            carInDb.NumberInStock = car.NumberInStock;
            carInDb.NumberAvailable = car.NumberAvailable;
            carInDb.TypeId = car.TypeId;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong. Make sure to specify the correct parameters");

            }



            return Ok("Edited car with Id " + id);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            var cars = _context.Cars.SingleOrDefault(c => c.Id == id);




            try
            {
                _context.Cars.Remove(cars);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest("Car wasn't removed. Make sure you have the correct Id");
            }



            return Ok("Deleted car with Id " + id);
        }
    }
}
