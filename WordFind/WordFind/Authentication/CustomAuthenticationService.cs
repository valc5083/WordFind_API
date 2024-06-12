using WordFind.Data;
using WordFind.Interface;
using WordFind.Model;

namespace WordFind.Authentication
{
    public class CustomAuthenticationService : IAuthenticationServices
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;

    public CustomAuthenticationService(IUserRepository userRepository, ITokenRepository tokenRepository)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
    }

    public bool isUserIdAvailable(string userId)
    {
        return _userRepository.getUserById(userId) == null;
    }

    public void registerUser(string userId, string password)
    {
        _userRepository.addUser(new UserItem { userId = userId, password = password });
    }

    public string authenticateUser(string userId, string password)
    {
        UserItem user = _userRepository.getUserById(userId);
        if (user != null && user.password == password)
        {
            string authToken = GenerateAuthToken();
            _tokenRepository.addToken(new AuthToken { token = authToken, userId = userId });
            return authToken;
        }
        return null;
    }

    private string GenerateAuthToken()
    {
        return Guid.NewGuid().ToString();
    }
}
}
