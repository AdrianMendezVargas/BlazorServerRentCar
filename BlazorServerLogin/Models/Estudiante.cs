using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerLogin.Models {
    public class Estudiante {

        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombres { get; set; }

        [Range(minimum: 1 , maximum: 10 , ErrorMessage = "Seleccione un semestre")]
        public int Semestre { get; set; }


        public string Nacionalidad { get; set; }

    }
}
