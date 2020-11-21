using System;
using System.Collections.Generic;
using System.Text;
using BlazorServerLogin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerLogin.Data {
    public class ApplicationDbContext : IdentityDbContext<Usuarios, IdentityRole<string>, string> {

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
    }
}
