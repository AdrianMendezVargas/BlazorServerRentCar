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
        private readonly CuotasBLL _cuotasBLL;

        public CobrosBLL(Contexto contexto , AppState appState , VentasBLL ventasBLL , CuotasBLL cuotasBLL) {
            _contexto = contexto;
            _appState = appState;
            _ventasBLL = ventasBLL;
            _cuotasBLL = cuotasBLL;
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
                        await AgregarPago(cobroDetalle.Monto , venta);
                    }
                    await _ventasBLL.Modificar(venta);
                }
            }
            return paso;
        }

        private async Task AgregarPago(decimal montoPago , Ventas venta) {

            venta.Cuotas = venta.Cuotas.OrderBy(c => c.Balance).ToList();
            foreach (var cuota in venta.Cuotas.Where(c => c.Pendiente)) {
                if (montoPago > cuota.Balance) {
                    venta.Balance -= cuota.Balance;
                    montoPago -= cuota.Balance;
                    cuota.Balance = 0;
                    await _cuotasBLL.Modificar(cuota);
                } else {
                    venta.Balance -= montoPago;
                    cuota.Balance -= montoPago;
                    montoPago = 0;
                    await _cuotasBLL.Modificar(cuota);
                    break;
                }
                
            }
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
                            foreach (var cuota in venta.Cuotas.OrderBy(c => c.Balance)) {
                                if (montoPago > cuota.Monto) {
                                    venta.Balance += cuota.Monto;
                                    montoPago -= cuota.Monto;
                                    cuota.Balance = cuota.Monto;
                                    await _cuotasBLL.Modificar(cuota);
                                } else {
                                    cuota.Balance += montoPago;
                                    venta.Balance += montoPago;
                                    montoPago = 0;
                                    await _cuotasBLL.Modificar(cuota);
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

        public async Task<List<Cobro>> GetCobros(Expression<Func<Cobro , bool>> expression , Paginacion paginacion) {
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
