using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models
{
    public class VentasCuotaDetalle
    {
        [Key]
        public int VentasDetalleId { get; set; }
        public int VentaId { get; set; }
        public int CuotaId { get; set; }
        public int VehiculoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
