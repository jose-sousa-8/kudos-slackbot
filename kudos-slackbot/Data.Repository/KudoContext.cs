namespace KudosSlackbot.Data.Repository
{
    using KudosSlackbot.Data.Dbo;

    using Microsoft.EntityFrameworkCore;

    public class KudoContext : DbContext
    {
        public KudoContext(DbContextOptions<KudoContext> options)
           : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Kudo> Kudos { get; set; }
    }
}
