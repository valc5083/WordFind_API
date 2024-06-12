namespace WordFind.Interface
{
    public interface IAuthenticationServices
    {
        bool isUserIdAvailable(string userId);
        void registerUser(string userId, string password);
        string authenticateUser(string userId, string password);
    }
}
