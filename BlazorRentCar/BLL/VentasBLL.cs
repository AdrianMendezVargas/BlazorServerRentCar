using BlazorRentCar.Data;
using BlazorRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.BLL
{
    public class VentasBLL
    {

        private readonly Contexto _contexto;

        public VentasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

      
       public bool Existe(int id)
        {
            bool encontrado = false;

            try
            {
                encontrado = _contexto.Ventas.Any(v => v.VentaId == id);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                
            }
            return encontrado;    
        }

     



    }
}
