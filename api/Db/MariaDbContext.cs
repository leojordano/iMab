using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Db 
{
    public class MariaDbContext : DbContext
    {
        private const string _connectionString = "server=localhost;port=3306;database=imab_db;user=imab_user;password=imab_password";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                _connectionString,
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
        public DbSet<User> Users { get; set; }
    }
}