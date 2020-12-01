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

     public Ventas Buscar(int id)
        {
            Ventas venta;
            try
            {
                venta = _contexto.Ventas
                    .Where(v => v.VentaId == id)
                    .Include(v => v.Cuotas)
                    .FirstOrDefault();

                venta = _contexto.Ventas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }
            return venta;
        }

       

    }
}
