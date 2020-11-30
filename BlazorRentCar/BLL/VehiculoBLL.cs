using BlazorRentCar.Data;
using BlazorRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlazorRentCar.Utilidades;

namespace BlazorRentCar.BLL
{
    public class VehiculoBLL
    {
        private readonly Contexto _contexto;

        public VehiculoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Vehiculo vehiculo)
        {

            if (! await Existe(vehiculo.VehiculoId))
                return await Insertar(vehiculo);
            else
                return await Modificar(vehiculo);
        }

        public async Task<bool> Insertar(Vehiculo vehiculo)
        {
            bool paso = false;
            try
            {
                _contexto.Vehiculos.Add(vehiculo);
                paso = await _contexto.SaveChangesAsync() > 0;
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

        public async Task<bool> Modificar(Vehiculo vehiculo)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(vehiculo).State = EntityState.Modified;
                paso = await _contexto.SaveChangesAsync() > 0;
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

        public async Task<bool> Existe(int id)
        {
            bool encontrado = false;
            try
            {
                encontrado = await _contexto.Vehiculos.AnyAsync(m => m.VehiculoId == id);
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

        public async Task<bool> Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var vehiculo = _contexto.Vehiculos.Find(id);
                if (vehiculo != null)
                {
                    _contexto.Vehiculos.Remove(vehiculo);
                    paso = await _contexto.SaveChangesAsync() > 0;
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

        public async Task<List<Vehiculo>> GetVehiculos(Expression<Func<Vehiculo, bool>> expression, Paginacion paginacion)
        {
            await Task.Delay(01); 

            var queryable = _contexto.Vehiculos.Where(expression).AsQueryable();
            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;

        }

        public async Task<int> Contar(Expression<Func<Vehiculo, bool>> expression)
        {
            return await _contexto.Vehiculos.AsQueryable().Where(expression).CountAsync();
        }

        public async Task<Vehiculo> Buscar(int id)
        {
            Vehiculo vehiculo;
            try
            {
                vehiculo = await _contexto.Vehiculos.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

            return vehiculo;
        }

    }
}
