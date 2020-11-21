using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models {
    public class Usuarios : IdentityUser<string> {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir su nombre de usuario")]
        public override string UserName { get; set; } = "";

        [StringLength(maximumLength: 30 , MinimumLength = 4 , ErrorMessage = "El Nombre es muy corto, favor introduzca de nuevo.")]
        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; } = "";

        [StringLength(maximumLength: 30 , MinimumLength = 4 , ErrorMessage = "El apellido es muy corto")]
        [Required(ErrorMessage = "Es obligatorio introducir el apellido")]
        public string Apellido { get; set; } = "";

        [Required(ErrorMessage = "Es obligatorio introducir el email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Introduzca una dirección valida")]
        public override string Email { get; set; } = "";

        [Required(ErrorMessage = "Es obligatorio introducir la contraseña")]
        [DataType(DataType.Password)]
        [StringLength(50 , ErrorMessage = "Debe contener mínimo 4 dígitos" , MinimumLength = 4)]
        public string Contraseña { get; set; } = "";



        public static string Encriptar(string Contraseña)
        {
            if (!string.IsNullOrEmpty(Contraseña)) {
                string resultado = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Contraseña);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }

            return string.Empty;
        }

        public static string DesEncriptar(string Contraseña)
        {
            if (!string.IsNullOrEmpty(Contraseña)) {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(Contraseña);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);
                return resultado;
            }

            return string.Empty;
        }



    }
}
