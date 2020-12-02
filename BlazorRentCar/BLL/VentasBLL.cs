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

namespace BlazorRentCar.BLL {
    public class VentasBLL {                

        private readonly Contexto _contexto;
        private readonly AppState _appState;
        private readonly ClientesBLL _clienteBLL;

        public VentasBLL(Contexto contexto , AppState appState, ClientesBLL clientesBLL) {
            _contexto = contexto;
            _appState = appState;
            _clienteBLL = clientesBLL;
        }

        public async Task<bool> Guardar(Ventas venta) {
            if (!await Existe(venta.VentaId))
                return await Insertar(venta);
            else
                return await Modificar(venta);
        }


        public async Task<bool> Existe(int id) {

            bool encontrado = false;

            try {
                encontrado = await _contexto.Ventas.AnyAsync(v => v.VentaId == id);
            } catch (Exception) {
                throw;
            } finally {
            }

            return encontrado;
        }


        public async Task<Ventas> Buscar(int id) {

            Ventas venta;

            try {
                venta = await _contexto.Ventas
                    .AsNoTracking()
                    .Where(v => v.VentaId == id)
                    .Include(v => v.Cuotas)
                    .FirstOrDefaultAsync();
            } catch (Exception) {
                throw;
            } finally {

            }

            return venta;
        }

        public async Task<bool> Modificar(Ventas venta) {
            bool paso = false;
            try {
                _contexto.Entry(venta).State = EntityState.Modified;

                paso = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(venta).State = EntityState.Detached;
            } catch (Exception) {
                throw;
            } finally {

            }
            return paso;
        }

        public async Task<bool> Insertar(Ventas venta) {
            bool paso = false;
            try {
                _contexto.Ventas.Add(venta);
                paso = _contexto.SaveChanges() > 0;
                if (paso) {
                    var cliente = await _clienteBLL.Buscar(venta.ClienteId);
                    if (cliente != null) {
                        await AsignarBalanceCliente(cliente);
                    }
                }
            } catch (Exception) {
                throw;
            } finally {

            }

            return paso;
        }

        private async Task AsignarBalanceCliente(Cliente cliente) {
            var Ventas = await _contexto.Ventas.Where(v => v.ClienteId == cliente.ClienteId).ToListAsync();
            cliente.Balance = 0;
            foreach (var venta in Ventas) {
                cliente.Balance += venta.Balance;
            }
            await _clienteBLL.Modificar(cliente);
        }

        public async Task<bool> Eliminar(int id) {
            bool paso = false;
            try {
                var venta = _contexto.Ventas.Find(id);

                if (venta != null) {
                    _contexto.Ventas.Remove(venta);
                    paso = _contexto.SaveChanges() > 0;
                    if (paso) {
                        var cliente = await _clienteBLL.Buscar(venta.ClienteId);
                        if (cliente != null) {
                            await AsignarBalanceCliente(cliente);
                        }
                    }
                }
            } catch (Exception) {
                throw;
            } finally {

            }

            return paso;
        }


        public async Task<List<Ventas>> GetVentas(Expression<Func<Ventas , bool>> expression , Paginacion paginacion, int  clienteId = 0) {
            await Task.Delay(01); //Para dar tiempo a renderizar el mensaje de carga

            var queryable = _contexto.Ventas.AsQueryable().Where(expression).Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name);
            
            if (clienteId > 0) {
                queryable = queryable.Where(v => v.ClienteId == clienteId);
            }

            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;

        }

        public async Task<int> Contar(Expression<Func<Ventas , bool>> expression, int clienteId = 0) {
            var queryable =  _contexto.Ventas.AsQueryable().Where(expression).Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name);
            if (clienteId > 0) {
                queryable = queryable.Where(v => v.ClienteId == clienteId);
            }
            return await queryable.CountAsync();
        }













    }
}
