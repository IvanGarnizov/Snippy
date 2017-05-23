namespace Snippy.Web.Models.ViewModels
{
    using System.Collections.Generic;

    public class LanguageSnippetsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}