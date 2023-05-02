using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Repository
{
    public class AboutRepository : IAbout
    {
        private readonly PorfolioContext _context;

        public AboutRepository (PorfolioContext context)
        {
            _context = context;
        }

        public void AddAbout(int id, AboutDto about)
        {
            _context.Add(about);
            _context.SaveChanges();
        }

        public About GetAbout(int id)
        {
            var UserAbout = _context.about.Include(x => x.address).FirstOrDefault(x => x.Id == id);

            return UserAbout;
        }

        public void removeAbout(int id)
        {
            var UserAbout = _context.about.FirstOrDefault(x => x.Id == id);
            if (UserAbout != null)
            {
                _context.Remove(UserAbout);
                _context.SaveChanges();
            }
        }

        public void updateAbout(int id, AboutDto about)
        {
            //var UserAbout = _context.about.Where(x => x.Id == id).Include(x => x.address).ToList();

            var UserAbout = _context.about.Include(x => x.address).FirstOrDefault(x => x.Id == id);

            if (UserAbout != null)
            {
                UserAbout.FirstName = about.FirstName;
                UserAbout.LastName = about.LastName;
                UserAbout.Email = about.Email;
                UserAbout.Phone = about.Phone;
                UserAbout.Age = about.Age;
                UserAbout.Description = about.Description;
                UserAbout.ImageUrl = about.ImageUrl;
                UserAbout.Git = about.Git;
                UserAbout.Linkedin = about.Linkedin;
                UserAbout.Gender = about.Gender;
                UserAbout.address.City = about.City;
                UserAbout.address.State = about.State;
                UserAbout.address.PostalCode = about.PostalCode;
                UserAbout.address.Country = about.Country;

                _context.SaveChanges();
            }
        }
    }
}
