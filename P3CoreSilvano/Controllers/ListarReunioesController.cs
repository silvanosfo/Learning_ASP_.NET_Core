using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P3CoreSilvano.Data;
using P3CoreSilvano.Models;

namespace P3CoreSilvano.Controllers
{
    public class ListarReunioesController : Controller
    {
        private readonly ApplicationDbContext db;

        public ListarReunioesController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index(int? idCli, int? idFunc)
        {
            ViewBag.CLIENTES = new SelectList(db.TClientes, "Id", "NomeCliente");
            ViewBag.FUNC = new SelectList(db.TFuncionarios, "Id", "NomeFunc");

            List<Reuniao> listaReunioes = new List<Reuniao>();

            if (idCli == null && idFunc == null)
            {
                //Mostra tudo
                listaReunioes = db.TReuniaos.Include(r => r.Cliente).Include(s => s.Funcionario).ToList();
            }
            else if (idFunc == null)
            {
                //Filtrado por Cliente
                listaReunioes = db.TReuniaos.Where( m => m.ClienteId == idCli).Include(r => r.Cliente).Include(s => s.Funcionario).ToList();
            }
            else if (idCli == null)
            {
                //Filtrado por Funcionário
                listaReunioes = db.TReuniaos.Where(m => m.FuncionarioId == idFunc).Include(r => r.Cliente).Include(s => s.Funcionario).ToList();
            }
            else
            {
                //Filtrado por Cliente e Funcionario
                listaReunioes = db.TReuniaos.Where(m => (m.ClienteId == idCli && m.FuncionarioId == idFunc)).Include(r => r.Cliente).Include(s => s.Funcionario).ToList();
            }

            ViewBag.COUNT = listaReunioes.Count();    

            return View(listaReunioes);
        }
    }
}
