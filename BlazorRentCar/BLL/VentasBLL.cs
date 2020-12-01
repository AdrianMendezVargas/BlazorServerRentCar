using BlazorRentCar.Data;
using BlazorRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRentCar.Utilidades;
using BlazorRentCar.ApplicationState;
using System.Linq.Expressions;

namespace BlazorRentCar.BLL
{
    public class VentasBLL
    {

        private readonly Contexto _contexto;
        private readonly AppState _appState;

        public VentasBLL(Contexto contexto, AppState appState)
        {
            _contexto = contexto;
            _appState = appState;
        }

        public  bool Guardar(Ventas venta)
        {
            if (!Existe(venta.VentaId))
                return Insertar(venta);
            else
                return Modificar(venta);
        }


        public  bool Existe(int id)
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
                _contexto.Dispose();
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

       public bool Modificar(Ventas venta)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(venta).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return paso;
        }

        public bool Insertar(Ventas venta)
        {
            bool paso = false;
            try
            {
                _contexto.Ventas.Add(venta);
                paso =  _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var venta = _contexto.Ventas.Find(id);

                if (venta != null)
                {
                    _contexto.Ventas.Remove(venta);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }

            return paso;
        }


        public async Task<List<Ventas>> GetVentas(Expression<Func<Ventas, bool>> expression, Paginacion paginacion)
        {
            await Task.Delay(01); //Para dar tiempo a renderizar el mensaje de carga

            var queryable = _contexto.Ventas.AsQueryable().Where(expression).Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name);
            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;

        }

        public async Task<int> Contar(Expression<Func<Ventas, bool>> expression)
        {
            return await _contexto.Ventas.AsQueryable().Where(expression).Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name).CountAsync();
        }













    }
}
