using BlazorRentCar.Data;
using BlazorRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRentCar.BLL {
    public class UserInfoBLL {

        private readonly Contexto _contexto;

        public UserInfoBLL(Contexto contexto) {
            _contexto = contexto;
        }

        public async Task<Usuarios> GetUsuario(string userName) {
            return await _contexto.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        }

    }
}
