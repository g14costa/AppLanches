using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraApp.Models
{
    public class Ingrediente
    {
        public Ingrediente(string nome)
        {
            Nome = nome;

            switch (nome)
            {
                case "Alface":
                default:
                    Valor = 0.40m;
                    break;
                case "Bacon":
                    Valor = 2.00m;
                    break;
                case "Hamburguer":
                    Valor = 3.00m;
                    break;
                case "Queijo":
                    Valor = 1.50m;
                    break;
                case "Ovo":
                    Valor = 0.80m;
                    break;
            }
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}