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
    public class CuotasBLL
    {
        private readonly Contexto _contexto;

        public CuotasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Cuotas cuota)
        {

            if (!Existe(cuota.CuotaId))
                return Insertar(cuota);
            else
                return Modificar(cuota);
        }

        public bool Insertar(Cuotas cuotas)
        {
            bool paso = false;
            try
            {
                _contexto.cuotas.Add(cuotas);
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

        public bool Modificar(Cuotas cuotas)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(cuotas).State = EntityState.Modified;
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

        public bool Existe(int id)
        {
            bool encontrado = false;
            try
            {
                encontrado = _contexto.cuotas.Any(m => m.CuotaId == id);
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

        public bool Eliminar (int id)
        {
            bool paso = false;
            try
            {
                var cuotas = _contexto.cuotas.Find(id);
                if(cuotas != null)
                {
                    _contexto.cuotas.Remove(cuotas);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {

            }
            return paso;

        }

        public async Task<List<Cuotas>> GetCuotas(Expression<Func<Cuotas, bool>> expression, Paginacion paginacion)
        {
            await Task.Delay(01); //Para dar tiempo a renderizar el mensaje de carga

            var queryable = _contexto.cuotas.Where(expression).AsQueryable();
            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;

        }

        public async Task<int> Contar(Expression<Func<Cuotas, bool>> expression)
        {
            return await _contexto.cuotas.AsQueryable().Where(expression).CountAsync();
        }

        public Cuotas Buscar(int id)
        {
            Cuotas cuotas;
            try
            {
                cuotas = _contexto.cuotas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

            return cuotas;
        }

    }
}
