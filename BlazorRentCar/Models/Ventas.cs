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
        public string UserName { get; set; }

        [Required(ErrorMessage = "Es obligatorio asignarle la venta a un cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio asignarle la venta a un vehículo")]
        public int VehiculoId { get; set; }

        public decimal Monto { get;  set; }
        public decimal Balance { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Today;
        public string Comentarios { get; set; }
       

        [ForeignKey("VentaId")]
        public virtual List<Cuota> Cuotas { get; set; } = new List<Cuota>();

        public void AgregarCuota(Cuota cuota) {
            Cuotas.Add(cuota);
            Monto += cuota.Monto;
            Balance += cuota.Balance;
        }
        public decimal GetBalance() {
            decimal balance = 0;
            foreach (var cuota in Cuotas) {
                balance += cuota.Balance;
            }
            return balance;
        }


        public Ventas(string userName) {
            UserName = userName;
        }

    }
}
