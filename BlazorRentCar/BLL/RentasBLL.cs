using BlazorRentCar.ApplicationState;
using BlazorRentCar.Data;
using BlazorRentCar.Models;
using BlazorRentCar.Models.Enums;
using BlazorRentCar.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorRentCar.BLL {
    public class RentasBLL {

        private readonly Contexto _contexto;
        private readonly AppState _appState;
        private readonly VehiculoBLL _vehiculosBLL;

        public RentasBLL(Contexto contexto , AppState appState, VehiculoBLL vehiculosBLL) {
            _contexto = contexto;
            _appState = appState;
            _vehiculosBLL = vehiculosBLL;
        }

        public async Task<bool> Guardar(Renta renta) {
            renta.UserName = _appState.ClaimsPrincipal.Identity.Name;

            if (!await Existe(renta.RentaId))
                return await Insertar(renta);
            else
                return await Modificar(renta);
        }

        private async Task<bool> Insertar(Renta renta) {
            bool paso = false;

            try {
                _contexto.Rentas.Add(renta);
                paso = await _contexto.SaveChangesAsync() > 0;

                if (paso) {
                    Vehiculo vehiculoRentado = await _vehiculosBLL.Buscar(renta.VehiculoId);
                    if (vehiculoRentado != null) {
                        vehiculoRentado.Estado = VehiculoEstado.Rentado;
                        await _vehiculosBLL.Modificar(vehiculoRentado);
                    }
                }
            } catch (Exception) {
                throw;
            } finally {
            }

            return paso;
        }

        public async Task<bool> Modificar(Renta renta) {
            bool paso = false;

            try {
                int vehiculoAnteriorId = (await Buscar(renta.RentaId)).VehiculoId;

                _contexto.Entry(renta).State = EntityState.Modified;
                paso = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(renta).State = EntityState.Detached;

                if (paso) {
                    Vehiculo vehiculoRentado = await _vehiculosBLL.Buscar(renta.VehiculoId);
                    if (vehiculoRentado != null) {

                        if (vehiculoRentado.VehiculoId != vehiculoAnteriorId) {

                            vehiculoRentado.Estado = VehiculoEstado.Rentado;
                            await _vehiculosBLL.Modificar(vehiculoRentado);

                            Vehiculo vehiculoAnterior = await _vehiculosBLL.Buscar(vehiculoAnteriorId);
                            if (vehiculoAnterior != null) {
                                vehiculoAnterior.Estado = VehiculoEstado.Disponible;
                                await _vehiculosBLL.Modificar(vehiculoAnterior);
                            }
                        }
                    }
                }

            } catch (Exception) {

                throw;
            } finally {
            }
            return paso;
        }

        public async Task<bool> Eliminar(int id) {
            bool paso = false;
            try {
                Renta renta = await _contexto.Rentas.Where(r => r.RentaId == id).FirstOrDefaultAsync();

                if (renta != null) {
                    _contexto.Rentas.Remove(renta);
                    paso = await _contexto.SaveChangesAsync() > 0;

                    if (paso) {
                        Vehiculo vehiculoRentado = await _vehiculosBLL.Buscar(renta.VehiculoId);
                        if (vehiculoRentado != null) {
                            vehiculoRentado.Estado = VehiculoEstado.Disponible;
                            await _vehiculosBLL.Modificar(vehiculoRentado);
                        }
                    }
                }
            } catch (Exception) {
                throw;
            } finally {
            }

            return paso;
        }

        public async Task<Renta> Buscar(int id) {
            Renta renta;

            try {
                renta = await _contexto.Rentas
                    .AsNoTracking()
                    .Where(e => e.RentaId == id)
                    .FirstOrDefaultAsync();
            } catch (Exception) {
                throw;
            } finally {
            }

            return renta;
        }


        public async Task<bool> Existe(int id) {
            bool encontrado = false;

            try {
                encontrado = await _contexto.Rentas.AsNoTracking().AnyAsync(e => e.RentaId == id);
            } catch (Exception) {
                throw;
            } finally {
            }

            return encontrado;
        }

        public async Task<List<Renta>> GetRentas(Expression<Func<Renta , bool>> expression , Paginacion paginacion) {
            await Task.Delay(01);

            var queryable = _contexto.Rentas.AsNoTracking()
                .AsQueryable()
                .Where(expression)
                .Where(v => v.UserName == _appState.ClaimsPrincipal.Identity.Name);

            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;
        }

        public async Task<int> Contar(Expression<Func<Renta , bool>> expression) {
            return await _contexto.Rentas.AsQueryable()
                .Where(expression)
                .Where(v => v.UserName == _appState.ClaimsPrincipal.Identity.Name)
                .CountAsync();
        }

    }
}
