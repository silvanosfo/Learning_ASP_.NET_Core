using Microsoft.EntityFrameworkCore;

using P3CoreSilvano.Models;
namespace P3CoreSilvano.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
            : base( options )   
        {
            
        }

        //aqui:
        public DbSet<Cliente>? TClientes { get; set; }
        public DbSet<Reuniao>? TReuniaos { get; set; }
        public DbSet<Funcionario>? TFuncionarios { get; set; }





    }
}

