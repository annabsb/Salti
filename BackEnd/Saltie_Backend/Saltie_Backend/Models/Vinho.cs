using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.Models
{
    public class Vinho
    {
        public string nome { get; set; } = string.Empty;
        public Tipo tipo { get; set; }
        public int valor { get; set; }
        public int qtd { get; set; }
        public int id { get; set; }

    }
}
