using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloseAndSlow.Models.ViewModels;


namespace CloseAndSlow.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Add()
        {
            return View();
        }
    
    
       
        [HttpPost]
        public ActionResult Add(ClienteViewModel model)

        {
            //  comprobamos que no exista nif ni mail, hacemos el insert y devolvemos mensaje usuario creado
            //correctamente. En caso de error devolvemos mensaje correspondiente
            return Content("");
        }

    }




}