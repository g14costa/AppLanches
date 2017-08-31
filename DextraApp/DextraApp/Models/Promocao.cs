using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraApp.Models
{
    public class Promocao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Regra { get; set; }
    }
}