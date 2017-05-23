namespace Snippy.Web.Models.ViewModels
{
    using System;

    public class SnippetCommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}