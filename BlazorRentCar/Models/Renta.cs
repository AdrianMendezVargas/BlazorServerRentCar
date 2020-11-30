using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorRentCar.Models {
    public class Renta {

        [Key]
        public int RentaId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage ="Seleccione un vehículo")]
        public int VehiculoId { get; set; }

        [Required]
        [Range(minimum: 1 , maximum: int.MaxValue , ErrorMessage = "Seleccione un cliente")]
        public int ClienteId { get; set; }

        [Required]
        public DateTime FechaInicial { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaFinal { get; set; } = DateTime.Now;

        [Required]
        public decimal MontoTotal { get; set; }

        public bool Eliminada { get; set; } = false;

        public virtual bool Activa => DateTime.Now < FechaFinal;

        public virtual int GetDiasRentados(){
            var timeSpam = FechaFinal.Date - FechaInicial.Date;
            return timeSpam.Days;
        }

        public Renta(string userName) {
            UserName = userName;
        }

    }
}
