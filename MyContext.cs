using Microsoft.EntityFrameworkCore;
using Pagos.Models;

namespace Pagos
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {
            
        }
        public DbSet<PagoModel> Pagos { get; set; }
        public DbSet<Comercio> Comercio { get; set; }
        public DbSet<Transaccion> Transaccion{ get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }

}
