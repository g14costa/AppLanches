using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraApp.Models
{
    public class Lanche
    {
        public Lanche(string nome)
        {
            Ingredientes = new List<Ingrediente>();

            switch (nome)
            {
                case "X-Bacon":                
                    Ingredientes.Add(new Ingrediente("Bacon"));
                    Ingredientes.Add(new Ingrediente("Hamburguer"));
                    Ingredientes.Add(new Ingrediente("Queijo"));                    
                    break;
                case "X-Burger":
                    Ingredientes.Add(new Ingrediente("Hamburguer"));
                    Ingredientes.Add(new Ingrediente("Queijo"));
                    break;
                case "X-Egg":
                    Ingredientes.Add(new Ingrediente("Hamburguer"));
                    Ingredientes.Add(new Ingrediente("Queijo"));
                    Ingredientes.Add(new Ingrediente("Ovo"));
                    break;
                case "X-Egg Bacon":
                    Ingredientes.Add(new Ingrediente("Hamburguer"));
                    Ingredientes.Add(new Ingrediente("Queijo"));
                    Ingredientes.Add(new Ingrediente("Ovo"));
                    Ingredientes.Add(new Ingrediente("Bacon"));
                    break;
                default:
                    break;
            }
            Nome = nome;
            Valor = Ingredientes.Sum(ing => ing.Valor);
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}