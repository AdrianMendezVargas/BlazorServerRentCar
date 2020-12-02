﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models {
    public class Cobro {

        [Key]
        public int CobroId { get; set; }

        [Range(minimum: 1 , maximum: int.MaxValue , ErrorMessage = "Seleccione una venta")]
        public int VentaId { get; set; }
        public string UserName { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Observaciones { get; set; } = "";
        public decimal Monto { get; private set; }

        [ForeignKey("CobroId")]
        public virtual List<CobroCuota> Detalles { get; set; } = new List<CobroCuota>();

        public void CalcularMonto() {
            Monto = 0m;
            foreach (var cobroDetalle in Detalles) {
                Monto += cobroDetalle.Monto;
            }
        }

        public decimal ObtenerMonto() {
            CalcularMonto();
            return Monto;
        }
    }
}
