using Microsoft.EntityFrameworkCore;
using BlazorRentCar.Data;
using BlazorRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorRentCar.Utilidades;
using System.Linq.Expressions;
using BlazorRentCar.Models.Interfaces;
using BlazorRentCar.ApplicationState;

namespace BlazorRentCar.BLL {
    public class ClientesBLL {

        private readonly Contexto _contexto;
        private readonly AppState _appState;

        public ClientesBLL(Contexto contexto, AppState appState) {
            _contexto = contexto;
            _appState = appState;
        }

        public async Task<bool> Guardar(Cliente cliente) {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        private async Task<bool> Insertar(Cliente cliente) {
            bool paso = false;


            try {
                _contexto.Clientes.Add(cliente);
                paso = await _contexto.SaveChangesAsync() > 0;
            } catch (Exception) {
                throw;
            } finally {
            }

            return paso;
        }

        public async Task<bool> Modificar(Cliente cliente) {
            bool paso = false;

            try {
                _contexto.Entry(cliente).State = EntityState.Modified;

                paso = await _contexto.SaveChangesAsync() > 0;

            } catch (Exception) {

                throw;
            } finally {
            }
            return paso;
        }

        public async Task<bool> Eliminar(int id) {
            bool paso = false;
            try {
                var cliente = _contexto.Clientes.Find(id);

                if (cliente != null) {
                    _contexto.Clientes.Remove(cliente);
                    paso = await _contexto.SaveChangesAsync() > 0;
                }
            } catch (Exception) {
                throw;
            } finally {
            }

            return paso;
        }

        public async Task<Cliente> Buscar(int id) {
            Cliente cliente;

            try {
                cliente = await _contexto.Clientes
                    .Where(e => e.ClienteId == id)
                    .FirstOrDefaultAsync();
            } catch (Exception) {
                throw;
            } finally {
            }

            return cliente;
        }


        public async Task<bool> Existe(int id) {
            bool encontrado = false;

            try {
                encontrado = await _contexto.Clientes.AnyAsync(e => e.ClienteId == id);
            } catch (Exception) {
                throw;
            } finally {
            }

            return encontrado;
        }

        public async Task<List<Cliente>> GetClientes(Expression<Func<Cliente, bool>> expression, Paginacion paginacion) {
            await Task.Delay(01); //Para dar tiempo a renderizar el mensaje de carga

            var queryable = _contexto.Clientes.AsQueryable().Where(expression).Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name);
            var lista = await queryable.Paginar(paginacion).ToListAsync();
            return lista;

        }

        public async Task<int> Contar(Expression<Func<Cliente , bool>> expression) {
            return await _contexto.Clientes.AsQueryable().Where(expression).Where(c => c.UserName == _appState.ClaimsPrincipal.Identity.Name).CountAsync();
        }

    }
}
