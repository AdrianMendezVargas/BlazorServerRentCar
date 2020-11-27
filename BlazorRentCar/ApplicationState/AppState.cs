using BlazorRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorRentCar.ApplicationState {
    public class AppState {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
