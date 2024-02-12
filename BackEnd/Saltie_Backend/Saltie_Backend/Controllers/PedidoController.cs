using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PedidoController : ControllerBase
    {
        [Authorize(Roles = "cliente")]
        [HttpPost("pedidos")]
        public IActionResult CadastraPedido([FromServices] AppDbContext context, [FromBody] PedidoCadastroViewModel model)
        {
            try
            {
                var user = context.Usuarios.FirstOrDefault(x => x.id == model.idUsuario);
                if (user == null)
                {
                    return NotFound(new { error = "Usuário não encontrado" });
                }

                int total = model.itens.Sum(item => item.qtd);

                var pedido = new Pedido
                {
                    usuario = user,
                    item = model.itens.Select(item => new ItemPedido
                    {
                        produto = context.Vinhos.Include(v => v.tipo).FirstOrDefault(x => x.id == item.idVinho),
                        qtd = item.qtd,
                    }).ToList(),
                    qtd = total,
                    Status = "Em Processamento",
                };
                if (pedido.qtd == 0)
                {
                    return BadRequest(new { error = "Escolha um item!" });
                }
                if (pedido.item == null)
                {
                    return BadRequest(new { error = "Item não encontrado!" });
                }

                context.Pedidos.Add(pedido);
                context.SaveChanges();

                return Ok(pedido);
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

                return StatusCode(500, new { error = "Erro interno do servidor" });
            }
        }

        [Authorize(Roles = "adm")]
        [HttpGet("pedidos")]
        public IActionResult ExibePedidos([FromServices] AppDbContext context)
        {
            try
            {
                var pedidos = context.Pedidos.Include(p => p.usuario).Include(p => p.item)
                    .ThenInclude(item => item.produto.tipo).ToList();


                return Ok(pedidos);
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

                return StatusCode(500, new { error = "Erro interno do servidor" });
            }
        }
        [HttpGet]
        [Route(template: "pedidos/{id}")]
        public async Task<IActionResult> GetByIdUserAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            try
            {
                var pedido = await context.Pedidos.Include(x => x.item)
                    .ThenInclude(item => item.produto).ThenInclude(produto => produto.tipo)
                    .Include(x => x.usuario).Where(x =>
                    x.usuario.id == id).ToListAsync();

                if (pedido == null)
                    return NotFound(new { message = "Usuário não possui pedidos!" });

                return Ok(pedido);
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

                return StatusCode(500, new { error = "Erro interno do servidor" });
            }
        }
        [HttpPut]
        [Route(template: "pedidos/atualiza/{idpedido}")]
        public async Task<IActionResult> AtualizaPedidos([FromServices] AppDbContext context, [FromRoute] int iduser, int idpedido)
        {
            try
            {
                var Pedidos = await context.Pedidos
                         .Include(x => x.usuario)
                         .Include(x => x.item).ThenInclude(x => x.produto).ThenInclude(x => x.tipo)
                         .FirstOrDefaultAsync(x => x.id == idpedido);
                if (Pedidos == null)
                {
                    return NotFound(new { error = "Pedidos não encontrado!" });
                }
                if (Pedidos.Status == "Em Processamento")
                {
                    Pedidos.Status = "Saiu para entrega";
                }
                else if (Pedidos.Status == "Saiu para entrega")
                {
                    Pedidos.Status = "Entregue!";
                }
                else
                {
                    return BadRequest(new { error = "Pedido já entregue!" });
                }
                context.Pedidos.Update(Pedidos);
                await context.SaveChangesAsync();
                return Ok(Pedidos);
            }
            catch
            {
                return StatusCode(500, new { error = "erro do servidor!!" });
            }
        }

    }
}
