using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.ViewModels
{
    public class TipoCadastroViewModel
    {
        [Required] public string nome { get; set; } = string.Empty;
    }
    public class TipoAtualizaViewModel
    {
        [Required] public string nome { get; set; } = string.Empty;

    }
}
