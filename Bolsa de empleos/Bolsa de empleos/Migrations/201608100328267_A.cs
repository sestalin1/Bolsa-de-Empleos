namespace Bolsa_de_empleos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaTrabajoes",
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
                .ForeignKey("dbo.CategoriaTrabajoes", t => t.categoriaID)
                .Index(t => t.categoriaID);
            
            CreateTable(
                "dbo.Configuracions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idioma = c.String(),
                        diasEmpleos = c.Int(nullable: false),
                        cantidadEmpleos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellido", c => c.String());
            AddColumn("dbo.AspNetUsers", "estatus", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "email", c => c.String());
            AddColumn("dbo.AspNetUsers", "rol", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApplicationRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "ApplicationRole_Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationRole_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Vacantes", "categoriaID", "dbo.CategoriaTrabajoes");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.Vacantes", new[] { "categoriaID" });
            DropColumn("dbo.AspNetUsers", "ApplicationRole_Id");
            DropColumn("dbo.AspNetUsers", "rol");
            DropColumn("dbo.AspNetUsers", "email");
            DropColumn("dbo.AspNetUsers", "estatus");
            DropColumn("dbo.AspNetUsers", "apellido");
            DropColumn("dbo.AspNetUsers", "nombre");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.Configuracions");
            DropTable("dbo.Vacantes");
            DropTable("dbo.CategoriaTrabajoes");
        }
    }
}
