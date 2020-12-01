using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models
{
    public class Cuota
    {
        [Key]
        public int CuotaId { get; set; }
        public int VentaId { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public bool EstaPagada => Balance == 0;

        public Cuota(decimal monto) {
            Monto = monto;
            Balance = monto;
        }

    }
}
