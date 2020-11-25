using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorRentCar.Models.Interfaces {
    public interface IBusinessLogic<T> {
        public Task<int> Contar(Expression<Func<T , bool>> expression);
    }
}
