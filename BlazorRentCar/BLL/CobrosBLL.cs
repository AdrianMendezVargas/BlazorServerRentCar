using BlazorRentCar.ApplicationState;
using BlazorRentCar.Data;
using BlazorRentCar.Models;
using BlazorRentCar.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorRentCar.BLL {
    public class CobrosBLL {

        private readonly Contexto _contexto;
        private readonly AppState _appState;
        private readonly VentasBLL _ventasBLL;

        public CobrosBLL(Contexto contexto , AppState appState, VentasBLL ventasBLL) {
            _contexto = contexto;
            _appState = appState;
            _ventasBLL = ventasBLL;
        }

        public async Task<bool> Guardar(Cobro cobro) {
            return await Insertar(cobro);
        }

        public async Task<bool> Insertar(Cobro cobro) {
            bool paso = false;
            cobro.UserName = _appState.ClaimsPrincipal.Identity.Name;
            cobro.CobroId = 0;

            _contexto.Cobros.Add(cobro);
            paso = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(cobro).State = EntityState.Detached;

            if (paso) {
                Ventas venta = await _ventasBLL.Buscar(cobro.VentaId);
                if (venta != null) {
                    foreach (var cobroDetalle in cobro.Detalles) {
                        venta.AgregarPago(cobroDetalle.Monto);
                    }
                    await _ventasBLL.Modificar(venta);
                }
            }
            return paso;
        }

        public async Task<bool> Eliminar(int id) {
            bool paso = false;
            try {
                var cobro = await Buscar(id);

                if (cobro != null) {
                    _contexto.Cobros.Remove(cobro);
                    paso = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(cobro).State = EntityState.Detached;

                    if (paso) {
                        Ventas venta = await _ventasBLL.Buscar(cobro.VentaId);
                        if (venta != null) {
                            decimal montoPago = cobro.Monto;
                            foreach (var cuota in venta.Cuotas.OrderBy(c=>c.Balance)) {
                                if (montoPago > cuota.Monto) {
                                    venta.Balance += cuota.Monto;
                                    montoPago -= cuota.Monto;
                                    cuota.Balance = cuota.Monto;
                                } else {
                                    cuota.Balance += montoPago;
                                    venta.Balance += montoPago;
                                    montoPago = 0;
                                    break;
                                }
                            }
                            await _ventasBLL.Modificar(venta);
                        }
                    }
                }
            } catch (Exception) {
                throw;
            } finally {
            }

            return paso;
        }

        public async Task<Cobro> Buscar(int id) {
            Cobro cobro;

            try {
                cobro = await _contexto.Cobros
                    .AsNoTracking()
                    .Include(c => c.Detalles)
                    .Where(v => v.CobroId == id)
                    .FirstOrDefaultAsync();
            } catch (Exception) {
                throw;
            } finally {
            }

            return cobro;
        }


        public async Task<bool> Existe(int id) {
            bool encontrado = false;

            try {
                encontrado = await _contexto.Cobros.AnyAsync(v => v.CobroId == id);
            } catch (Exception) {
                throw;
            } finally {
            }

            return encontrado;
        }

        public async Task<List<Cobro>> GetClientes(Expression<Func<Cobro , bool>> expression , Paginacion paginacion) {
            await Task.Delay(01);

            var queryable = _contexto.Cobros
                .AsNoTracking()
                .AsQueryable()
                .Where(expression)
                .Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name);

            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;

        }

        public async Task<int> Contar(Expression<Func<Cobro , bool>> expression) {
            return await _contexto.Cobros.AsQueryable()
                .Where(expression)
                .Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name)
                .CountAsync();
        }
    }
}
