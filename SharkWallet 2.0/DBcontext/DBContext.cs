using Microsoft.EntityFrameworkCore;
using SharkWallet_2._0.entidades;
using SharkWallet_2._0.Entidades;

namespace SharkWallet_2._0.DBcontext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Monedas>? Monedas { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Billetera>? Billetera { get; set; }
        public DbSet<Balance>? Balances { get; set; }
        public DbSet<LogIn>? LogIn { get; set; }
    }
}