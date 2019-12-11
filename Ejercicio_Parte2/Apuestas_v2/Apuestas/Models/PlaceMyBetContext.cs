//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    //esta clase que conecta con la BD Y Crea la estructura de tablas (la relaciones entre ellas se crea en los modelos)
    public class PlaceMyBetContext:DbContext
    {
       //se indican las tablas que se va a crear(llamada a tus modelos)
        public DbSet<Mercado> Mercado { get; set; } 
        public DbSet<Apuesta> Apuesta { get; set; }
        public DbSet<Login> Usuario { get; set; }
        public DbSet<Partido> Partido { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        //crear el contructor 
        public PlaceMyBetContext()
        {
        }
        public PlaceMyBetContext(DbContextOptions options)
            :base(options)
        {
        }
        //Metodo de cadena de conexion a la BD 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=apuesta4;Uid=root;password=root;SslMode=none");//màquina retos

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //crear datos usuario
            //modelBuilder.Entity<Login>().HasData(new Login(1, "35062900K", "joandemonserrat@gmail.com", "Joan", "De Monserrat"));
            //modelBuilder.Entity<Cuentas>().HasData(new Cuentas(1, "0000111122223333", "Santander", 100, 1));
            modelBuilder.Entity<Partido>().HasData(new Partido(1, "Sevilla", "Betis", 1.5, 4));
            //modelBuilder.Entity<Mercado>().HasData(new Mercado((float)1.5,(float)20.40,(float) 5.5, 100,200,1));
            //modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 200, (float)5.5,'O', 1,(float) 1.5));
            //base.OnModelCreating(modelBuilder);
        }
    }
}