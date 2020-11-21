using BlazorServerLogin.Data;
using BlazorServerLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerLogin.BLL {
    public class EstudiantesBLL {

        private ApplicationDbContext contexto;

        public EstudiantesBLL(ApplicationDbContext _contexto) {
            contexto = _contexto;
        }

        public async Task<bool> Guardar(Estudiante estudiante) {
            if (!await Existe(estudiante.EstudianteId))
                return await Insertar(estudiante);
            else
                return await Modificar(estudiante);
        }

        private async Task<bool> Insertar(Estudiante estudiante) {
            bool paso = false;
            

            try {
                contexto.Estudiantes.Add(estudiante);
                paso = await contexto.SaveChangesAsync() > 0;
            } catch (Exception) {
                throw;
            } 

            return paso;
        }

        public async Task<bool> Modificar(Estudiante estudiante) {
            bool paso = false;
            

            try {
                contexto.Entry(estudiante).State = EntityState.Modified;

                paso = await contexto.SaveChangesAsync() > 0;

            } catch (Exception) {

                throw;
            } 
            return paso;
        }

        public async Task<bool> Eliminar(int id) {
            bool paso = false;
            
            try {
                var estudiante = contexto.Estudiantes.Find(id);

                if (estudiante != null) {
                    contexto.Estudiantes.Remove(estudiante);
                    paso = await contexto.SaveChangesAsync() > 0;
                }
            } catch (Exception) {
                throw;
            } 

            return paso;
        }

        public async Task<Estudiante> Buscar(int id) {
            Estudiante estudiante;

            try {
                estudiante = await contexto.Estudiantes
                    .Where(e => e.EstudianteId == id)
                    .FirstOrDefaultAsync();
            } catch (Exception) {
                throw;
            } 

            return estudiante;
        }


        public async Task<bool> Existe(int id) {
            bool encontrado = false;

            try {
                encontrado = await contexto.Estudiantes.AnyAsync(e => e.EstudianteId == id);
            } catch (Exception) {
                throw;
            } 

            return encontrado;
        }

        public async Task<List<Estudiante>> GetEstudiantes() {

            List<Estudiante> estudiantes = new List<Estudiante>();
            await Task.Delay(01); //Para dar tiempo a renderizar el mensaje de carga

            try {
                estudiantes = await contexto.Estudiantes.ToListAsync();

            } catch (Exception) {

                throw;
            } 

            return estudiantes;

        }

    }
}
