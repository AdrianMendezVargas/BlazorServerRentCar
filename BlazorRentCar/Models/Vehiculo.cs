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
        [Required(ErrorMessage = "Es obligatorio asignarle al vehiculo un importador")]
        [ForeignKey("ImportadorId")]

        public int ImportadorId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la matricula")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la placa")]
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
        public int Ano { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el chassis")]
        public string Chassis { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad de pasajeros")]
        public string Pasajeros { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad de puertas")]
        public string Puertas { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la traccion del vehiculo")]
        public string Traccion { get; set; }
        public string Comentario { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el valor del vehiculo")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el tipo")]
        public string Tipo { get; set; }

        public Vehiculo(string userName)
        {
            VehiculoId = 0;
            ImportadorId = 0;
            Matricula = "";
            Marca = "";
            Modelo = "";
            Placa = "";
            AñoFabricacion = DateTime.Now;
            Estado = VehiculoEstado.Disponible;
            PrecioDia = 0m;
            Chassis = "";
            Pasajeros = "";
            Puertas = "";
            Traccion = "";
            Comentario = "";
            Valor = 0m;
            Tipo = "";


        }

    }
}
