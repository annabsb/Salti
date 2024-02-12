using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public int usuarioId { get; set; }
        public List<ItemPedido> item { get; set; }
        public int qtd { get; set; }
        public string Status { get; set; } = string.Empty;

    }
}
