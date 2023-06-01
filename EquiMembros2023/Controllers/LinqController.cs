using EquiMembros2022.Data;
using EquiMembros2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquiMembros2023.Controllers
{
    public class LinqController : Controller
    {
        private readonly ApplicationDbContext db;

        public LinqController(ApplicationDbContext context)
        {
            db = context;
        }

        public string nomeEquipa = "";

        public IActionResult Linq(string nomeequipa, int num)
        {
            ViewBag.TOTAL = db.Tequipas.Count();
            ViewBag.ORDASC = db.Tequipas.OrderBy(s => s.NomeEquipa);
            ViewBag.ORDDESC = db.Tequipas.OrderByDescending(s => s.NomeEquipa);

            try
            {
                ViewBag.NUM = db.Tequipas.Find(num).NomeEquipa;
            }
            catch (Exception)
            {

                ViewBag.NUM = "A equipa não existe";
            }

            ViewBag.UM = db.Tequipas.First().NomeEquipa;


            var resultado = db.Tequipas.Where(m => m.NomeEquipa == nomeequipa);
            int existe = resultado.Count();

            if (existe > 0)
            {
                ViewBag.EXISTE = "Sim";
            }
            else
            {
                ViewBag.EXISTE = "Não";
            }

            ViewBag.NMEMBROS = db.Tmembros.Where(m => m.EquipaId == num).Count();
            
            ViewBag.NMEMBROS2 = db.Tmembros.Where(s => s.EquipaId == db.Tequipas.FirstOrDefault(m => m.NomeEquipa == nomeequipa).Id).Count();

            ViewBag.MAIOR = db.Tmembros.Max(s => s.Id);

            ViewBag.EQUIMENOR = db.Tequipas.Min(s => s.Id);

            ViewBag.SOMAIDEQUIP = db.Tequipas.Sum(s => s.Id);

            ViewBag.SOMAIDEQUIPNOME = db.Tequipas.Where(s => s.NomeEquipa == nomeequipa).Sum(s => s.Id);

            ViewBag.SOMAIDMEMBROS = db.Tmembros.Where(s => s.EquipaId == db.Tequipas.FirstOrDefault(m => m.NomeEquipa == nomeequipa).Id).Sum(x => x.Id);

            ViewBag.ABELCOUNT = db.Tmembros.Where(s => s.NomeMembro == "Abel").GroupBy(m => m.EquipaId).Count();

            ViewBag.NMMAXFALC = db.Tmembros.Where(m => m.EquipaId == db.Tequipas.First(s => s.NomeEquipa == "Maximinense").Id).Count() +
                                db.Tmembros.Where(m => m.EquipaId == db.Tequipas.First(s => s.NomeEquipa == "Falcões do Picoto").Id).Count();

            int idMax = db.Tequipas.FirstOrDefault(s => s.NomeEquipa == "Maximinense").Id;
            int idFalc = db.Tequipas.FirstOrDefault(s => s.NomeEquipa == "Falcões do Picoto").Id;

            ViewBag.LISTORDNMAXFALC = db.Tmembros.Where(m => (m.EquipaId == idMax || m.EquipaId == idFalc)).
                                      OrderBy(m => m.NomeMembro).Select(m => m.NomeMembro);

            return View();
        }

        public IActionResult Teste()
        {
            return View();
        }
    }
}
