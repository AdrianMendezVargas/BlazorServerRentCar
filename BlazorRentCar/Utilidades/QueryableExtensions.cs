using BlazorRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.Utilidades {
    public static class QueryableExtensions {

        public static IQueryable<T> Paginar<T>(this IQueryable<T> query, Paginacion paginacion) {

            return query.Skip((paginacion.Pagina - 1) * paginacion.CantidadPorPagina)
                .Take(paginacion.CantidadPorPagina);

        } 

    }
}
