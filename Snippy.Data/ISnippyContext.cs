namespace Snippy.Data
{
    using System.Data.Entity;

    using Models;

    public interface ISnippyContext
    {
        IDbSet<Snippet> Snippets { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Language> Languages { get; set; }

        IDbSet<Label> Labels { get; set; }
    }
}