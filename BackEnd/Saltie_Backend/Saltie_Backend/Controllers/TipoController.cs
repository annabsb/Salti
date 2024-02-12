using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saltie_Backend.Data;
using Saltie_Backend.Models;
using Saltie_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltie_Backend.Controllers
{
    [ApiController]
    public class TipoController : ControllerBase
    {
        [Authorize(Roles = "adm")]
        [HttpPost]
        [Route(template: "tipos")]
        public async Task<IActionResult> CadastroTipoAsync([FromServices] AppDbContext context,
                                                           [FromBody] TipoCadastroViewModel model)
        {
            try
            {
                var tipo = context.Tipos.FirstOrDefault(x => x.nome == model.nome);
                if (tipo!=null)
                {
                    return BadRequest(new { error = "Tipo já cadastrado!" });
                }
                var novoTipo = new Tipo
                {
                    nome = model.nome
                };
                await context.Tipos.AddAsync(novoTipo);
                await context.SaveChangesAsync();
                return Created($"{novoTipo.id}", novoTipo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar usuário: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    Console.WriteLine($"Inner Exception StackTrace: {ex.InnerException.StackTrace}");
                }

                return StatusCode(500, new { error = "Erro interno do servidor!!" });
            }

        }
        [HttpGet("tipos")]
        public IActionResult ExibeTipos([FromServices] AppDbContext context)
        {
            try
            {
                var tipos = context.Tipos.ToList();
                return Ok(tipos);
            }
            catch
            {
                return StatusCode(500, new { error = "Erro no servidor!" });
            }
        }
    }
}
