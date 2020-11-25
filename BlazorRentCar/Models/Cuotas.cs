using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models
{
    public class Cuotas
    {
        [Key]
        public int CuotaId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el concepto de la cuota")]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el monto de la cuota")]

        public double Monto { get; set; }

    }
}
