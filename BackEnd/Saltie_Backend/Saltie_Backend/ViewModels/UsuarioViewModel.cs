using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.ViewModels
{
    public class UsuarioCadastroViewModel
    {
        [Required][EmailAddress] public string email { get; set; } = string.Empty;
        [Required] public string nome { get; set;} = string.Empty;
        [Required] public string senha { get; set; }
    }
    public class UsuarioLoginViewModel
    {
        [Required][EmailAddress] public string email { get; set; } = string.Empty;
        [Required] public string senha { get; set; } = string.Empty;
    }
    public class UserAtualizaViewModel
    {
        [Required][EmailAddress] public string email { get; set; } = string.Empty;
        [Required] public string senha { get; set; } = string.Empty;
        [Required]public string nome { get; set; } = string.Empty;

    }
}
