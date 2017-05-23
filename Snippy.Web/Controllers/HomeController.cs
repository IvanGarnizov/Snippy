using AutoMapper;
using Snippy.Data.UnitOfWork;
using Snippy.Models;
using Snippy.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var snippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreationTime)
                .Take(5)
                .ToList();
            var comments = this.Data.Comments.All()
                .OrderByDescending(c => c.CreationTime)
                .Take(5)
                .ToList();
            var labels = this.Data.Labels.All()
                .OrderByDescending(l => l.Snippets.Count)
                .Take(5)
                .ToList();
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);
            var commentModels = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(comments);
            var labelModels = Mapper.Map<IEnumerable<Label>, IEnumerable<LabelViewModel>>(labels);
            var homeViewModel = new HomeViewModel();

            homeViewModel.Snippets = snippetModels;
            homeViewModel.Comments = commentModels;
            homeViewModel.Labels = labelModels;

            return View(homeViewModel);
        }
    }
}