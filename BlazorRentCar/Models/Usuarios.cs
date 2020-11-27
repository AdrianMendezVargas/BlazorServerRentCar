using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models {
    public class Usuarios : IdentityUser<string> {
        [Key]
        [PersonalData]
        [Required(ErrorMessage = "Es obligatorio introducir su nombre de usuario")]
        public override string UserName { get; set; } = "";

        [PersonalData]
        [StringLength(maximumLength: 30 , MinimumLength = 4 , ErrorMessage = "El Nombre es muy corto, favor introduzca de nuevo.")]
        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; } = "";

        [PersonalData]
        [StringLength(maximumLength: 30 , MinimumLength = 4 , ErrorMessage = "El apellido es muy corto")]
        [Required(ErrorMessage = "Es obligatorio introducir el apellido")]
        public string Apellido { get; set; } = "";

        [PersonalData]
        [Required(ErrorMessage = "Es obligatorio introducir el email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Introduzca una dirección valida")]
        public override string Email { get; set; } = "";

        public Usuarios() : base(){
            
        }

        public Usuarios(IdentityUser user){
            Id = user.Id;
        }

    }
}
