using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using P3CoreSilvano.Data;
using P3CoreSilvano.Models;

namespace P3CoreSilvano.Controllers
{
    public class ListReunNomeCliController : Controller
    {
        private readonly ApplicationDbContext db;

        public ListReunNomeCliController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index(string? nomeCli)
        {
            List<Reuniao> listaReunioes = new List<Reuniao>();

            if (nomeCli != null)
            {
                listaReunioes = db.TReuniaos.Where(m => m.Cliente.NomeCliente
                            .Contains(nomeCli)).Include(r => r.Cliente).Include(s => s.Funcionario).ToList();

            }
            else
            {
                listaReunioes = db.TReuniaos.Include(r => r.Cliente).Include(s => s.Funcionario).ToList();
            }

            return View(listaReunioes);
        }
    }
}
