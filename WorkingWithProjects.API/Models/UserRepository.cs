using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDB _context;

        public UserRepository(ContextDB contextDB)
        {
            _context = contextDB;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }
    }
}