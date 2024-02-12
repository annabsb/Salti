using Microsoft.AspNetCore.Mvc;
using Saltie_Backend.Data;
using Saltie_Backend.Models;
using Saltie_Backend.Services;
using Saltie_Backend.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Saltie_Backend.Controllers
{
    [ApiController]

    public class VinhoController : ControllerBase
    {
        [Authorize(Roles = "adm")]
        [HttpPost]
        [Route(template: "vinhos")]
        public async Task<IActionResult> CadastroVinhoAsync([FromServices] AppDbContext context, [FromBody] VinhoCadastroViewModel model)
        {
            try
            {
                var VinhoExiste = await context.Vinhos.AnyAsync(x => x.nome == model.nome);
                if (VinhoExiste)
                {
                    return BadRequest(new { error = "Vinho já cadastrado!" });
                }
                var tipovinho = context.Tipos.FirstOrDefault(x => x.id == model.idTipo);
                if (tipovinho == null) return BadRequest(new { error = "Tipo de vinho não cadastrado!" });
                var novoVinho = new Vinho
                {

                    nome = model.nome,
                    tipo = tipovinho,
                    valor = model.valor,
                    qtd = model.qtd
                    
                };
                await context.Vinhos.AddAsync(novoVinho);
                await context.SaveChangesAsync();
                return Created($"{novoVinho.id}", novoVinho);
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
        [HttpGet("vinhos")]
        public IActionResult ExibeVinhos([FromServices] AppDbContext context)
        {
            try
            {
                var vinhos = context.Vinhos.Include(v => v.tipo).ToList();

                return Ok(vinhos);
            }
            catch
            {
                return StatusCode(500, new { error = "Erro no servidor" });
            }
        }
        [HttpGet("vinhos/{id}")]
        public IActionResult ExibeVinhoPorId([FromServices] AppDbContext context,
                                             [FromRoute] int id)
        {
            try
            {
                var vinho = context.Vinhos.Include(v => v.tipo).FirstOrDefault(x => x.id == id);
                return Ok(vinho);
            }
            catch
            {
                return StatusCode(500, new { error = "Erro no servidor" });
            }
        }
        [Authorize(Roles = "adm")]
        [HttpPut("vinhos/{id}")]
        public IActionResult AtualizaVinho([FromServices] AppDbContext context,
                                                       [FromRoute] int id,
                                                       [FromBody] VinhoAtualizaViewModel model)
        {
            try
            {
                var vinho = context.Vinhos.FirstOrDefault(x => x.id == id);
                if (vinho == null)
                {
                    return NotFound(new { error = "Produto não encontrado!" });
                }
                var tipo = context.Tipos.FirstOrDefault(x => x.id == model.idTipo);
                if (tipo == null)
                {
                    return NotFound(new { error = "Tipo de vinho inexistente!" });
                }
                vinho.nome = model.nome;
                vinho.tipo = tipo;
                vinho.valor = model.valor;
                vinho.qtd = model.qtd;
                context.SaveChanges();
                return Ok(vinho);
            }
            catch
            {
                return StatusCode(500, new { error = "Erro do servidor!" });
            }
        }
        [Authorize(Roles = "adm")]
        [HttpDelete("vinhos/{id}")]
        public IActionResult DeletaVinho([FromServices] AppDbContext context,
                                         [FromRoute] int id)
        {
            var vinho = context.Vinhos.FirstOrDefault(x => x.id == id);
            if (vinho == null)
            {
                return NotFound(new { error = "Vinho não encontrado!" });
            }
            context.Vinhos.Remove(vinho);
            context.SaveChanges();
            return Ok();
        }
    }
}
