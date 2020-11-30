using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorRentCar.Models {
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Usuarios , IdentityRole<string>> {
        public MyUserClaimsPrincipalFactory(
            UserManager<Usuarios> userManager ,
            RoleManager<IdentityRole<string>> roleManager ,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager , roleManager , optionsAccessor) {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Usuarios user) {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("Email" , user.Email ?? ""));
            identity.AddClaim(new Claim("Nombre" , user.Nombre ?? ""));
            identity.AddClaim(new Claim("Apellido" , user.Apellido ?? ""));

            return identity;
        }
    }
}
