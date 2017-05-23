namespace Snippy.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;

    using Models;

    public class SnippyContext : IdentityDbContext<User>, ISnippyContext
    {
        public SnippyContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnippyContext, Configuration>());
        }

        public virtual IDbSet<Snippet> Snippets { get; set; }

        public virtual IDbSet<Language> Languages { get; set; }

        public virtual IDbSet<Label> Labels { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static SnippyContext Create()
        {
            return new SnippyContext();
        }
    }
}
