using Microsoft.EntityFrameworkCore;
using Saltie_Backend.Models;

namespace Saltie_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vinho> Vinhos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> Itens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=C:/Users/Dell/Desktop/Saltie/BackEnd/Saltie_Backend/Saltie_Backend/Saltie.db;Cache=Shared");

    }
}
