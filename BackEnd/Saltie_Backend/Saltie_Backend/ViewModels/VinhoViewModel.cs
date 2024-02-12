using Saltie_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.ViewModels
{
    public class VinhoCadastroViewModel
    {
        public string nome { get; set; } = string.Empty;
        public int idTipo { get; set; } 
        public int valor { get; set; }
        public int qtd { get; set; }
    }
    public class VinhoAtualizaViewModel
    {
        public string nome { get; set; } = string.Empty;
        public int idTipo { get; set; }
        public int valor { get; set; }
        public int qtd { get; set; }
    }
}
