using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltieFrontEnd
{
    internal class Pedido
    {
        public int idusuario { get; set; }
        public List<ItemPedidoSender> itens { get; set; } = new List<ItemPedidoSender>();
        public int qtd { get; set; }

    }
}
