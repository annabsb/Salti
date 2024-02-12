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

    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route(template: "login")]
        public async Task<IActionResult> LoginAsync([FromServices] AppDbContext context, [FromBody] UsuarioLoginViewModel model)
        {
            try
            {
                var user = await context.Usuarios.FirstOrDefaultAsync(x => x.email == model.email && x.senha == Settings.GenerateHash(model.senha));
                if (user == null)
                {
                    return NotFound(new { error = "Usuario não encontrado!" });
                }
                var token = TokenServices.GenerateToken(user);
                return Ok(new { user = user, token = token });
            }
            catch
            {
                return StatusCode(500, new { error = "erro do servidor!!" });
            }
        }
        [HttpPost]
        [Route(template: "cadastro")]
        public async Task<IActionResult> CadastroAsync([FromServices] AppDbContext context, [FromBody] UsuarioCadastroViewModel model)
        {
            try
            {
                var user = await context.Usuarios.FirstOrDefaultAsync(x => x.email == model.email);
                if (user != null)
                {
                    return BadRequest(new { error = "Email já cadastrado!!" });
                }
                var newuser = new Usuario
                {
                    email = model.email,
                    senha = Settings.GenerateHash(model.senha),
                    nome = model.nome,
                    cargo = "cliente"
                };
                await context.Usuarios.AddAsync(newuser);
                await context.SaveChangesAsync();
                return Created($"{newuser.id}", newuser);
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
        [Authorize(Roles = "adm")]
        [HttpGet("usuarios")]
        public IActionResult ExibeUsuarios([FromServices] AppDbContext context)
        {
            try
            {
                var users = context.Usuarios.ToList();
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, new { error = "Erro no servidor" });
            }
        }
        [Authorize(Roles = "adm")]
        [HttpDelete("usuarios/{id}")]
        public IActionResult ApagaUsuario([FromServices] AppDbContext context,
                                          [FromRoute] int id)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.id == id);
                if (usuario == null)
                {
                    return NotFound(new { error = "Usuário não encontrado!" });
                }
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return Ok();
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
    }
}
