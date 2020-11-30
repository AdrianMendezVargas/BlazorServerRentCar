using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models {
    public class Vigencia {
        [Key]
        public int VigenciaId { get; set; }
        public DateTime FechaInicial { get; set; } = DateTime.Now;
        public DateTime FechaFinal { get; set; } = DateTime.Now;
    }
}
