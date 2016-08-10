namespace Bolsa_de_empleos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriasTrabajo",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.Vacantes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        categoriaID = c.String(maxLength: 128),
                        fechaPublicacion = c.DateTime(nullable: false),
                        estatus = c.Boolean(nullable: false),
                        ubicacion = c.String(),
                        posicion = c.String(),
                        empresa = c.String(),
                        tipoTrabajo = c.String(),
                        logo = c.String(),
                        descripcion = c.String(),
                        comoAplicar = c.String(),
                        accesibilidad = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CategoriasTrabajo", t => t.categoriaID)
                .Index(t => t.categoriaID);
            
            CreateTable(
                "dbo.Configuraciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idioma = c.String(),
                        diasEmpleos = c.Int(nullable: false),
                        cantidadEmpleos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        nombre = c.String(),
                        apellido = c.String(),
                        estatus = c.Boolean(),
                        email = c.String(),
                        webSite = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ApplicationRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationRole_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vacantes", "categoriaID", "dbo.CategoriasTrabajo");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.Vacantes", new[] { "categoriaID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Configuraciones");
            DropTable("dbo.Vacantes");
            DropTable("dbo.CategoriasTrabajo");
        }
    }
}
