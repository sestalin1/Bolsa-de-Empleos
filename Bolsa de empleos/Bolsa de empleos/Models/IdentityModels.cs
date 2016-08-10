using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Bolsa_de_empleos.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }

        [Required]
        public bool estatus { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        [ForeignKey("Roles")]
        public string rol { get; set; }
        //public ApplicationRole role { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {

        public ICollection<ApplicationUser> user { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BolsaDeEmpleosConnection")
        {
            
        }
        public DbSet<Vacante> Vacantes { get; set; }
        public DbSet<Configuracion> configuraciones { get; set; }
        public DbSet<CategoriaTrabajo> CategoriasTrabajo { get; set; }
    }

    public class AppInitializer : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole {Id="adm", Name="Administrador" },
                new ApplicationRole {Id="usr", Name="User" },
                new ApplicationRole {Id="pst", Name="Poster" },
                new ApplicationRole {Id="aft", Name="Affiliate" }
            };

            roles.ForEach(g => context.Roles.Add(g));
            context.SaveChanges();

            var conf = new List<Configuracion>
            {
                new Configuracion { id=1,idioma="esp",cantidadEmpleos=30,diasEmpleos=5}
            };

            conf.ForEach(g => context.configuraciones.Add(g));
            context.SaveChanges();

            var usu = new List<ApplicationUser>
            {
                new ApplicationUser {UserName="ses",nombre="JL",apellido="DR",email="mail@text.com",estatus=true,rol="adm",PasswordHash="123@A"}
            };

            usu.ForEach(g => context.Users.Add(g));
            context.SaveChanges();

        }
    }
}