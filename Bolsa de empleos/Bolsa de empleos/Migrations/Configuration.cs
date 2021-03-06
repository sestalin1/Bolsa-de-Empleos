namespace Bolsa_de_empleos.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<Bolsa_de_empleos.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Bolsa_de_empleos.Models.ApplicationDbContext";
        }

        protected override void Seed(Bolsa_de_empleos.Models.ApplicationDbContext context)
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
                new ApplicationUser {UserName="ses",nombre="JL",apellido="DR",email="mail@text.com",estatus=true,PasswordHash="AOF23mAs35cIHYrSc2rUVmUiSTSyndUi7CSvysQZhtDt6AiZ84E25/UQTkWn/8H1aw==",SecurityStamp="e0f867c0-3fd3-43ad-8332-f3a8540f3555" }

            };

            usu.ForEach(g => context.Users.Add(g));
            //usu.ForEach(g => g.Roles.Add(new IdentityUserRole { UserId =g.UserName, RoleId = "user" }));
            context.SaveChanges();

            //Roles.Add(new IdentityUserRole { UserId = model.UserName, RoleId = "user" });
            //context.SaveChanges();


        }
    }
}
