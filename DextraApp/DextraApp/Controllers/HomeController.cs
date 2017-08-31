using DextraApp.Models;
using DextraApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DextraApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ListagemLancheIngredienteViewModel lanchesIngredientes = new ListagemLancheIngredienteViewModel();

            lanchesIngredientes.Ingredientes.Add(new Ingrediente("Alface"));
            lanchesIngredientes.Ingredientes.Add(new Ingrediente("Bacon"));
            lanchesIngredientes.Ingredientes.Add(new Ingrediente("Hamburguer"));
            lanchesIngredientes.Ingredientes.Add(new Ingrediente("Ovo"));
            lanchesIngredientes.Ingredientes.Add(new Ingrediente("Queijo"));

            lanchesIngredientes.Lanches.Add(new Lanche("X-Bacon"));
            lanchesIngredientes.Lanches.Add(new Lanche("X-Egg"));
            lanchesIngredientes.Lanches.Add(new Lanche("X-Burger"));
            lanchesIngredientes.Lanches.Add(new Lanche("X-Egg Bacon"));

            return View(lanchesIngredientes);
        }
    }
}