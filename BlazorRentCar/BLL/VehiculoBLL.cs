using BlazorRentCar.Data;
using BlazorRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorRentCar.BLL
{
    public class VehiculoBLL
    {
        private readonly Contexto _contexto;

        public VehiculoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Vehiculo vehiculo)
        {

            if (!Existe(vehiculo.VehiculoId))
                return Insertar(vehiculo);
            else
                return Modificar(vehiculo);
        }

        public bool Insertar(Vehiculo vehiculo)
        {
            bool paso = false;
            try
            {
                _contexto.Vehiculos.Add(vehiculo);
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

        public bool Modificar(Vehiculo vehiculo)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(vehiculo).State = EntityState.Modified;
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
                encontrado = _contexto.Vehiculos.Any(m => m.VehiculoId == id);
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

        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var vehiculo = _contexto.Vehiculos.Find(id);
                if (vehiculo != null)
                {
                    _contexto.Vehiculos.Remove(vehiculo);
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

        public List<Vehiculo> GetList(Expression<Func<Vehiculo, bool>> criterio)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            try
            {
                lista = _contexto.Vehiculos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return lista;
        }

        public Vehiculo Buscar(int id)
        {
            Vehiculo vehiculo;
            try
            {
                vehiculo = _contexto.Vehiculos.Find(id);
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
