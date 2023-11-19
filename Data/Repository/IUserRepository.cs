using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using YoMarket.Models;

namespace YoMarket.Data.Repository
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);
        void AddUser(User user);
        User GetUserForLogin(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        EshopContext _context;
        public UserRepository(EshopContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserForLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.password == password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

    }
}
