using System;
using System.Collections.Generic;
using System.Text;
using BlazorRentCar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorRentCar.Data {
    public class ApplicationDbContext : IdentityDbContext<Usuarios, IdentityRole<string>, string> {

        public DbSet<Usuarios> Usuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
    }
}
