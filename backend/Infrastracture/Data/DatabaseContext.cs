using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        private string serverLinkString;
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DatabaseContext(string serverLinkString)
        {
            this.serverLinkString = serverLinkString;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<SkillsDex> SkillsDex { get; set; }
        public virtual DbSet<SkillsCha> SkillsCha { get; set; }
        public virtual DbSet<SkillsInt> SkillsInt { get; set; }
        public virtual DbSet<SkillsStr> SkillsStr { get; set; }
        public virtual DbSet<SkillsWis> SkillsWis { get; set; }
        public virtual DbSet<Spell> Spell { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Modificators> Modificators { get; set; }
        public virtual DbSet<Characteristics> Characteristics { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Appearance> Appearance { get; set; }
        public virtual DbSet<PlayerList> PlayerList { get; set; }
    }
}
