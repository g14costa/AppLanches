using DextraApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraApp.ViewModel
{
    public class ListagemLancheIngredienteViewModel
    {
        public ListagemLancheIngredienteViewModel()
        {
            Ingredientes = new List<Ingrediente>();
            Lanches = new List<Lanche>();
        }

        public List<Ingrediente> Ingredientes { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}