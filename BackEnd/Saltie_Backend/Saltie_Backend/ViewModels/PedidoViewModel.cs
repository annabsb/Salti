using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.ViewModels
{
    public class PedidoCadastroViewModel
    {
        public int idUsuario { get; set; }
        public List<ItemPedidoViewModel> itens { get; set; }

    }
}
