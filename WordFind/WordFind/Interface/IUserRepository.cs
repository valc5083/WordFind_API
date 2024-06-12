using WordFind.Model;

namespace WordFind.Interface
{
    public interface IUserRepository
    {
        UserItem getUserById(string userId);
        void addUser(UserItem user);
    }
}