using WordFind.Model;

namespace WordFind.Interface
{
    public interface ITokenRepository
    {
        void addToken(AuthToken token);
        bool isTokenValid(string token);
    }
}