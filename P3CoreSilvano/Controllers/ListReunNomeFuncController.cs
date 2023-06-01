using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3CoreSilvano.Data;
using P3CoreSilvano.Models;

namespace P3CoreSilvano.Controllers
{
    public class ListReunNomeFuncController : Controller
    {
        private readonly ApplicationDbContext db;

        public ListReunNomeFuncController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index(string? nomeFunc)
        {
            List<Reuniao> listaReunioes = new List<Reuniao>();

            listaReunioes = db.TReuniaos.Where(s => s.Funcionario.NomeFunc.Contains(nomeFunc))
                            .Include(r => r.Cliente).Include(s => s.Funcionario).ToList();

            ViewBag.MIN = listaReunioes.Sum(m => m.Duracao);

            return View(listaReunioes);
        }
    }
}
