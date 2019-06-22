using Rent_a_Car.Models;
using System;


namespace Rent_a_Car.Helpers
{
    public class Helper
    {

        private ApplicationDbContext _context;


        public Helper()
        {
            _context = new ApplicationDbContext();


        }

        public string GetName(string id)
        {
            var user = _context.Users.Find(id).Name;
            return user;
        }

        public DateTime GetBirthDate(string id)
        {
            var user = _context.Users.Find(id).BirthDate;

            return user;
        }

        public string GetAddress(string id)
        {
            var user = _context.Users.Find(id).Address;

            return user;
        }
    }
}