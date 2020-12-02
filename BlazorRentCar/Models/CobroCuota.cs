using System.ComponentModel.DataAnnotations;

namespace BlazorRentCar.Models {
    public class CobroCuota {
        [Key]
        public int CobroDetalleId { get; set; }
        public int CobroId { get; set; }
        public decimal Monto { get; set; }

        public CobroCuota(decimal monto) {
            Monto = monto;
        }
    }
}