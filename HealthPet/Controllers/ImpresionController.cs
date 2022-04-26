using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace HealthPet.Controllers
{
    public class ImpresionController : Controller
    {
        public IActionResult Generar()
        {
            return new ViewAsPdf("Generar");//NOmbre de la vista
        }
    }
}
