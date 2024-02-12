using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.Models
{
    public class ItemPedido
    {
        public int id { get; set; }
        public Vinho produto { get; set; }
        public int qtd { get; set; }

    }
}
