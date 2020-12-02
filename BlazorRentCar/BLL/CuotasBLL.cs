using BlazorRentCar.Data;
using BlazorRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.BLL {
    public class CuotasBLL {

        private readonly Contexto _contexto;

        public CuotasBLL(Contexto contexto) {
            _contexto = contexto;
        }

        public async Task<bool> Modificar(Cuota cuota) {
            bool paso = false;

            try {
                _contexto.Entry(cuota).State = EntityState.Modified;
                paso = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(cuota).State = EntityState.Detached;
            } catch (Exception) {

                throw;
            } finally {
            }
            return paso;
        }

    }
}
