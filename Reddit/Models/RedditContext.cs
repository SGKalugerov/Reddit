namespace Reddit.Models
{
    using System.Data.Entity;

    public class RedditContext : DbContext
    {
        public RedditContext() => Database.SetInitializer<RedditContext>(null);
        public DbSet<Topic> Topics { get; set; }
    }
}