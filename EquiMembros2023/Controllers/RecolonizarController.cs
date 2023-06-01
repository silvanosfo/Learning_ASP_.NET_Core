using EquiMembros2023.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquiMembros2023.Controllers
{
    public class RecolonizarController : Controller
    {
        public IActionResult Index()
        {
            ConectarEColonizar obj = new ConectarEColonizar();

            obj.RecolonizarTabelaDeEquipas();
            obj.RecolonizarTabelaDeMembros();

            return View();
        }
    }
}
