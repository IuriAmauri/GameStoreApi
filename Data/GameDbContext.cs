using GameStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}