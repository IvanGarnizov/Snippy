namespace Snippy.Web.Controllers
{
    using AutoMapper;
    using Snippy.Data.UnitOfWork;
    using Snippy.Models;
    using Snippy.Web.Models.ViewModels;
    using System.Linq;
    using System.Web.Mvc;

    public class LanguagesController : BaseController
    {
        public LanguagesController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Snippets(int id)
        {
            var language = this.Data.Languages.All()
                .First(l => l.Id == id);
            var languageModel = Mapper.Map<Language, LanguageSnippetsViewModel>(language);

            return View(languageModel);
        }
    }
}