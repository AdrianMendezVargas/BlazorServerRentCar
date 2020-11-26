using System;
using System.Collections.Generic;
using System.Text;
using BlazorRentCar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorRentCar.Data {
    public class Contexto : IdentityDbContext<Usuarios, IdentityRole<string>, string> {

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Cuotas> cuotas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 1, Nombres = "Adrian1", Apellidos = "Mendez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 2, Nombres = "Adrian2" , Apellidos = "Mendez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 3, Nombres = "Adrian3" , Apellidos = "Mendez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 4, Nombres = "Adrian4" , Apellidos = "Mendez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 5, Nombres = "Adrian5" , Apellidos = "Mendez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 6, Nombres = "Juan6" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 7, Nombres = "Juan7" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 8, Nombres = "Juan8" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 9, Nombres = "Juan9" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 10 , Nombres = "Juan10" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 11 , Nombres = "Juan11" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 12 , Nombres = "Juan12" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 13 , Nombres = "Juan13" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 14 , Nombres = "Juan14" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 15 , Nombres = "Juan15" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 16 , Nombres = "Juan16" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 17 , Nombres = "Juan17" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 18 , Nombres = "Juan18" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 19 , Nombres = "Juan19" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 20 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 21 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 22 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 23 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 24 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 25 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 26 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 27 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 28 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 29 , Nombres = "Juan20" , Apellidos = "Perez" });
            builder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 30 , Nombres = "Juan20" , Apellidos = "Perez" });
        }
    }
}
