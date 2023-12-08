using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloseAndSlow.Models.ViewModels
{
    /// <summary>
    /// Clase que  controla y valida los datos de las reservas
    /// </summary>
    public class ReservaViewModel

    {

        [Required]
        [Display(Name = "Fecha de entrada")]
        [DataType(DataType.Date)]
        public string FechaDesde { get; set; }

        [Required]
        [Display(Name = "Fecha de salida")]
        [DataType(DataType.Date)]
        public string FechaHasta { get; set; }
        public int IdCliente {  get; set; }
        public int IdHotel {  get; set; }
        public int IdHabitacion {  get; set; }
        public DateTime FechaReserva { get; set; }
        public int Precio { get; set; } 


    }
}