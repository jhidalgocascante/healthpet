using Microsoft.AspNetCore.Mvc;
using HealthPet.Models;
using HealthPet.Datos;
using Rotativa.AspNetCore;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System;
using System.Web;
using System.Data;

namespace HealthPet.Controllers
{
    public class CitaController : Controller
    {

        CitaDatos _CitaDatos = new CitaDatos();

        public IActionResult Listar()
        {
            //la vista mostrará una lista de contactos
            var oLista = _CitaDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //Devolver solo la vista formato hmtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CitaModel oCita)
        {

            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _CitaDatos.Guardar(oCita);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        //visualiza el objeto con el boton editar
        public IActionResult Editar(int CodCita)
        {
            //Devolver solo la vista formato hmtml
            var oAvion = _CitaDatos.Obtener(CodCita);
            return View(oAvion);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Editar(CitaModel oCita)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _CitaDatos.Editar(oCita);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        //visualiza el objeto con el boton editar
        public IActionResult Eliminar(int CodCita)
        {
            //Devolver solo la vista formato hmtml
            var ocontacto = _CitaDatos.Obtener(CodCita);
            return View(ocontacto);
        }

        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Eliminar(CitaModel oCita)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _CitaDatos.Eliminar(oCita.CodCita);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Generar(int CodCita)
        {

            //Devolver solo la vista formato hmtml
            var oCita = _CitaDatos.Obtener(CodCita);
            //return View(oAvion);
            return View(oCita);
            //return new ViewAsPdf("Generar", oCita);//Nombre de la vista
            //return new ActionAsPdf("Generar", oCita);
        }


        //recibe el objeto que se ha modificado para ajustarlo con el objeto
        [HttpPost]
        public IActionResult Generar(CitaModel oCita)
        {
            //Valido si existe algun tipo de validacion que revisar y pendiente
            if (!ModelState.IsValid)
                return View();

            //metodo recibe el objeto para guardarlo en bd
            var respuesta = _CitaDatos.Eliminar(oCita.CodCita);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Export(int CodCita)
        {

            //Devolver solo la vista formato hmtml
            var oCita = _CitaDatos.Obtener(CodCita);
            //return View(oAvion);
            return View(oCita);
            //return new ViewAsPdf("Generar", oCita);//Nombre de la vista
            //return new ActionAsPdf("Generar", oCita);
        }

        //[ValidateInput(false)]
        [HttpPost]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {

                return File(System.Text.Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "Grid.xls");
    



        /*StringReader sr = new StringReader(GridHtml);
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        pdfDoc.Open();
        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        pdfDoc.Close();
        return File(stream.ToArray(), "application/pdf", "Grid.pdf");*/
    }
}

    }
}
