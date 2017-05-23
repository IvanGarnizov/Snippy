namespace Snippy.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.UnitOfWork;
    using AutoMapper;
    using Snippy.Web.Models.ViewModels;
    using Snippy.Models;

    public class LabelsController : BaseController
    {
        public LabelsController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Snippets(int id)
        {
            var label = this.Data.Labels.All()
                .First(l => l.Id == id);
            var labelModel = Mapper.Map<Label, LabelSnippetsViewModel>(label);

            return View(labelModel);
        }
    }
}