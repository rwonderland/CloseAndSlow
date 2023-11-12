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
        [Display(Name ="Nombre completo")]
        public string Nombre{ get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion{ get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono {  get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        [StringLength(20, ErrorMessage = "El nombre de usuario no puede tener menos de  {2}  caracteres", MinimumLength = 3)]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "NIF")]
        public string Nif {  get; set; }

        [Display(Name = "Tarjeta Bancaria(opcional)")]
        [DataType(DataType.CreditCard)]
        public string Tarjeta { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(50,ErrorMessage ="La contraseña no puede tener menos de  {2}  caracteres",MinimumLength =8)]
        public string Contrasenha { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contrasenha",ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmaContrasenha { get; set; }

        public string Error {  get; set; }

    }
}