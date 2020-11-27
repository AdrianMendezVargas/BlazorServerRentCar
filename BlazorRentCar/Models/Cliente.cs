using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorRentCar.Models {
    public class Cliente {
        [Key]
        public int ClienteId { get; set; }
        
        public string UserName { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Este email no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Phone(ErrorMessage = "El teléfono es invalido")]
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Cliente(string userName) {
            UserName = userName;
            ClienteId = 0;
            Nombres = "";
            Apellidos = "";
            Email = "";
            Direccion = "";
            FechaRegistro = DateTime.Today;
            Telefono = "";
        }

    }
}
