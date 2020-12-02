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
        public DbSet<Renta> Rentas { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            Ventas venta = new Ventas("styles") {
                VentaId = 1 ,
                ClienteId = 1 ,
                Comentarios = "comment" ,
                VehiculoId = 1,
                Monto = 10000,
                Balance = 10000
            };

            builder.Entity<Ventas>().HasData(venta);

            for (int i = 0 ; i < 10 ; i++) {
                builder.Entity<Cuota>().HasData(new Cuota(1000) { VentaId = venta.VentaId , CuotaId = i + 1 });
            }


        }

    }
}
