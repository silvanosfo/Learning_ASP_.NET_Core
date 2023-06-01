using P3CoreSilvano.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using P3CoreSilvano.Data;
using Microsoft.EntityFrameworkCore;

namespace P3CoreSilvano.Controllers
{
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            ViewBag.REUNIOESANA = db.TReuniaos.Where(m => m.Funcionario.NomeFunc == "Ana Fonseca").Count();

            ViewBag.REUNIOESCARPX = db.TReuniaos.Where(m => m.Cliente.NomeCliente == "CarpintariaX, Lda").Count();

            ViewBag.MINJOAO = db.TReuniaos.Where(m => m.Funcionario.NomeFunc == "João Costa").Sum(r => r.Duracao);

            return View();
        }

     
    }
}


