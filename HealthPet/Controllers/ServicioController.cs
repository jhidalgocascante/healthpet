using Microsoft.AspNetCore.Mvc;
using HealthPet.Datos;
using HealthPet.Models;


namespace HealthPet.Controllers
{
    public class ServicioController : Controller
    {

        ServicioDatos _ServicioDatos = new ServicioDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _ServicioDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ServicioModel oServicio)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _ServicioDatos.Guardar(oServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodServicio)
        {
            //Devolver solo la vista formato hmtml
            var oServicio = _ServicioDatos.Obtener(CodServicio);
            return View(oServicio);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(ServicioModel oServicio)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _ServicioDatos.Editar(oServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodServicio)
        {
            //Devolver solo la vista formato hmtml
            var oServicio = _ServicioDatos.Obtener(CodServicio);
            return View(oServicio);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(ServicioModel oServicio)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _ServicioDatos.Eliminar(oServicio.CodServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
