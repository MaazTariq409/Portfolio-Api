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

        public AboutRepository(PorfolioContext context)
        {
            _context = context;
        }

        public void AddAbout(int id, About about)
        {
            var UserAbout = new About();
            if(about != null)
            {
                UserAbout.UserID = id;
                UserAbout.Name = about.Name;
                UserAbout.Email = about.Email;
                UserAbout.Phone = about.Phone;
                UserAbout.Age = about.Age;
                UserAbout.Description = about.Description;
                UserAbout.ImageUrl = about.ImageUrl;
                UserAbout.Git = about.Git;
                UserAbout.Linkedin = about.Linkedin;
                UserAbout.Gender = about.Gender;
                UserAbout.Address = about.Address;
                UserAbout.Introduction = about.Introduction;
                UserAbout.Language = about.Language;
            }

            _context.about.Add(UserAbout);
            _context.SaveChanges();

        }

        public About GetAbout(int id)
        {
            var UserAbout = _context.about.FirstOrDefault(x => x.Id == id);

            return UserAbout;
        }

        public void removeAbout(int id)
        {
            var UserAbout = _context.about.FirstOrDefault(x => x.UserID == id);
            if (UserAbout != null)
            {
                _context.Remove(UserAbout);
                _context.SaveChanges();
            }
        }

        public void updateAbout(int id, AboutDto about)
        {
            //var UserAbout = _context.about.Where(x => x.Id == id).Include(x => x.address).ToList();

            var UserAbout = _context.about.FirstOrDefault(x => x.UserID == id);

            if (UserAbout != null)
            {
                UserAbout.Name = about.Name;
                UserAbout.Email = about.Email;
                UserAbout.Phone = about.Phone;
                UserAbout.Age = about.Age;
                UserAbout.Description = about.Description;
                UserAbout.ImageUrl = about.ImageUrl;
                UserAbout.Git = about.Git;
                UserAbout.Linkedin = about.Linkedin;
                UserAbout.Gender = about.Gender;
                UserAbout.Address = about.Address;
                UserAbout.Introduction = about.Introduction;
                UserAbout.Language = about.Language;

                _context.SaveChanges();
            }
        }
    }
}
