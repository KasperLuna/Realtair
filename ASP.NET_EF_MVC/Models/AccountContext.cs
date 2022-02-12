using System.Data.Entity;

namespace WebApplication1.Models
{
    public class AccountContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}