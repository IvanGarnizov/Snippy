namespace Snippy.Web.Models.ViewModels
{
    using System;

    public class CommentViewModel
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public string SnippetTitle { get; set; }

        public int SnippetId { get; set; }
    }
}