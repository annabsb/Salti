
using System.ComponentModel.DataAnnotations;

namespace Saltie_Backend.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public string cargo { get; set; } = string.Empty;
    }
}
