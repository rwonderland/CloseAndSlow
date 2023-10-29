using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CloseAndSlow.Models.ViewModels
{
    public class ClienteViewModel
    {
        [Required]
        public string Nombre{ get; set; }
        [Required]
        public string Direccion{ get; set; }
        [Required]
        public string Telefono {  get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Nif {  get; set; }       
        public string Tarjeta { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50,ErrorMessage ="La contraseña no puede tener menos de  {1}  caracteres",MinimumLength =8)]
        public string Contrasenha { get; set; }
        [Compare("Contrasenha",ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmaContrasenha { get; set; }

    }
}