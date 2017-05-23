namespace Snippy.Web.Models.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class SnippetDetailsViewModel
    {
        public int Id { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime CreationTime { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<SnippetLabelViewModel> Labels { get; set; }

        public IEnumerable<SnippetCommentViewModel> Comments { get; set; }
    }
}