using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WordFind.Model;

namespace WordFind.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }

        
    }
}
