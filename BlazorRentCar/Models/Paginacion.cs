using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models {
    public class Paginacion {
        public int Pagina { get; set; } = 1;
        public int CantidadPorPagina { get; set; } = 5;
    }
}
