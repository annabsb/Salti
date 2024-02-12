using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltieFrontEnd
{
    public class VinhoSender
    {
        public string nome { get; set; } = string.Empty;
        public int idTipo { get; set; }
        public int valor { get; set; }
        public int qtd { get; set; }
    }
    public class VinhoUpdater
    {
        public string nome { get; set; } = string.Empty;
        public int idTipo { get; set; }
        public int valor { get; set; }
    }
}
