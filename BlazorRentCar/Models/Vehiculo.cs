using BlazorRentCar.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorRentCar.Models {
    public class Vehiculo
    {
        [Key]
        public int VehiculoId { get; set; }
        public string UserName { get; set; }
        public string Placa { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el Año de fabricacion")]
        public DateTime AñoFabricacion { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el estado del vehiculo")]
        public VehiculoEstado Estado { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el precio")]
        public decimal PrecioDia { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el kilometraje")]
        public int Kilometraje { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el Año del vehiculo")]
        public string Chassis { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad de pasajeros")]
        public int Pasajeros { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad de puertas")]
        public int Puertas { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la traccion del vehiculo")]
        public string Traccion { get; set; }
        public string Comentario { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el valor del vehiculo")]
        public decimal Valor { get; set; }
        public string Tipo { get; set; }

        public Vehiculo(string userName)
        {
            UserName = userName;
            VehiculoId = 0;
            Marca = "";
            Modelo = "";
            Placa = "";
            AñoFabricacion = DateTime.Now;
            Estado = VehiculoEstado.Disponible;
            PrecioDia = 0m;
            Chassis = "";
            Pasajeros = 0;
            Puertas = 0;
            Traccion = "";
            Comentario = "";
            Valor = 0m;
            Tipo = "";


        }

    }
}
