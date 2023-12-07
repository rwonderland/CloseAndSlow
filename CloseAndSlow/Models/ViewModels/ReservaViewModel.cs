﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloseAndSlow.Models.ViewModels
{
    //Los viewModel solo muestran datos, la lógica se gestiona a través la propia clase, no desde el ViewModel
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


    }
}