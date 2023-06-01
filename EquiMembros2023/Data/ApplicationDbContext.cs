using Microsoft.EntityFrameworkCore;

using EquiMembros2022.Models;
using EquiMembros2023.Models;

namespace EquiMembros2022.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base( options )   
        {
            
        }

        public DbSet<Equipa> Tequipas { get; set; }

        public DbSet<Membro> Tmembros { get; set; }
        public DbSet<Cliente> Tclientes { get; set; }
    }
}

