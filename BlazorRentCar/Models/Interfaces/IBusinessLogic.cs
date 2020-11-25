using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Models.Interfaces {
    public interface IBusinessLogic {
        public Task<int> Contar();
    }
}
