using System;
using System.Collections.Generic;
using System.Text;
using BlazorRentCar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorRentCar.Data {
    public class Contexto : IdentityDbContext<Usuarios, IdentityRole<string>, string> {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Cuotas> cuotas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) {
        }

    }
}
