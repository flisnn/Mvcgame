using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mvcgame.Models;

namespace Mvcgame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mvcgame.Models.game_character> game_character { get; set; } = default!;
        public DbSet<Mvcgame.Models.Armors> Armors { get; set; } = default!;
        public DbSet<Mvcgame.Models.Potions> Potions { get; set; } = default!;
        public DbSet<Mvcgame.Models.Weapons> Weapons { get; set; } = default!;
    }
}
