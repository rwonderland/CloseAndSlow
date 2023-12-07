using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloseAndSlow.Models.ViewModels
{
    public class HabitacionViewModel
    {
        public int Id { get; set; }
        public string Capacidad { get; set;}
        public int Precio {  get; set;} 
        public int IdHotel { get; set;}
    }
}