using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        [Required(ErrorMessage = "Es obligatorio asignarle la venta a un cliente")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Seleccione un tipo de factura")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Debe seleccionar el tipo de factura")]
        public int TipoFactura { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el total")]
        public double Total { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el ITBIS")]
        public double ITBIS { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir los descuentos")]
        public double Descuentos { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el total general")]
        public double TotalGeneral { get; set; }
        public string Comentarios { get; set; }
        public int CantidadVehiculos { get; set; }
       
        [ForeignKey("VentaId")]
        public virtual List<VentasCuotaDetalle> VentaDetalle { get; set; } = new List<VentasCuotaDetalle>();




    }
}
