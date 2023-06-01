using EquiMembros2022.Data;
using EquiMembros2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquiMembros2023.Controllers
{
    public class ListagemEquipasController : Controller
    {
        //declaração do apontador para a base de dados
        private readonly ApplicationDbContext dbPointer;

        //no construtor da classe
        public ListagemEquipasController(ApplicationDbContext context)
        {
            dbPointer = context;
        }
        public IActionResult ListagemEquipas(int equipas)
        {
            ViewBag.EQUIPAS = dbPointer.Tequipas.ToList();
            ViewBag.MEMBROS = dbPointer.Tmembros.ToList();

            SelectList listEquip = new SelectList(dbPointer.Tequipas, "Id", "NomeEquipa");
            ViewBag.LISTEQUIP = listEquip;

            SelectList listMemb = new SelectList(dbPointer.Tmembros, "Id", "NomeMembro", "EquipaId");
            ViewBag.LISTMemb = listMemb;

            try
            {
                ViewBag.EQUIPAID = dbPointer.Tequipas.Find(equipas);
            }
            catch (Exception)
            {
                ;
                //ViewBag.EQUIPAID = "Equipa não selecionada!";
            }
            return View();
        }
    }
}
