namespace Snippy.Web.Models.ViewModels
{
    using System.Collections.Generic;

    public class LabelSnippetsViewModel
    {
        public string Text { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}