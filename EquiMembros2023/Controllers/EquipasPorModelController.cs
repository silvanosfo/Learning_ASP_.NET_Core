using EquiMembros2022.Data;
using EquiMembros2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquiMembros2023.Controllers
{
    public class EquipasPorModelController : Controller
    {
        private readonly ApplicationDbContext db;

        public EquipasPorModelController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult EquipasPorModel()
        {
            EquipasMembros vm = new EquipasMembros();
            vm.Equipas = db.Tequipas.ToList();
            vm.Membros = db.Tmembros.ToList();

            return View(vm);
        }
    }
}
