using WordFind.Data;
using WordFind.Interface;
using WordFind.Model;

namespace WordFind.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly MyDbContext _dbContext;

        public TokenRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void addToken(AuthToken token)
        {
            _dbContext.AuthTokens.Add(token);
            _dbContext.SaveChanges();
        }

        public bool isTokenValid(string token)
        {
            return _dbContext.AuthTokens.Any(t => t.token == token);
        }
    }
}