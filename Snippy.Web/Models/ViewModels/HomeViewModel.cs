namespace Snippy.Web.Models.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<SnippetViewModel> Snippets { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }
    }
}