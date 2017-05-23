namespace Snippy.Web.Models.ViewModels
{
    using System.Collections.Generic;

    public class SnippetViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<SnippetLabelViewModel> Labels { get; set; }
    }
}