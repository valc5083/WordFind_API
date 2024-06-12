using WordFind.Data;
using WordFind.Interface;
using WordFind.Model;

namespace WordFind.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public UserItem getUserById(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.userId == userId);
        }

        public void addUser(UserItem user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
