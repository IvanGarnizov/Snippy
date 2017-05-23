namespace Snippy.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.UnitOfWork;

    using Models.ViewModels;

    using Snippy.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Snippy.Web.Models;
    using System;
    using PagedList;

    public class SnippetsController : BaseController
    {
        public SnippetsController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.All()
                .First(s => s.Id == id);
            
            snippet.Comments = snippet.Comments
                .OrderByDescending(c => c.CreationTime)
                .ToList();

            var snippetModel = Mapper.Map<Snippet, SnippetDetailsViewModel>(snippet);

            this.ViewBag.UserId = this.User.Identity.GetUserId();

            return View(snippetModel);  
        }

        public ActionResult Index(int? page)
        {
            var snippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreationTime)
                .ToList();
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);
            int pageSize = 5;
            int pageNumber = page ?? 1;

            return View(snippetModels.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult UserSnippets()
        {
            var userId = this.User.Identity.GetUserId();
            var snippets = this.Data.Users.All()
                .First(u => u.Id == userId)
                .Snippets;
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);

            return View(snippetModels);
        }

        [Authorize]
        public ActionResult NewSnippet()
        {
            var languages = new List<SelectListItem>();

            languages.AddRange(this.Data.Languages.All()
                .Select(l => new SelectListItem()
                {
                    Text = l.Name
                }));

            this.ViewBag.Languages = languages;

            return View(new SnippetBindingModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnippetBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var labels = model.Labels.Split(';').Select(l => l.Trim()).ToList();
            var labelsInDb = new List<Label>();

            foreach (var label in labels)
            {
                var labelInDb = this.Data.Labels.All()
                    .FirstOrDefault(l => l.Text == label);

                if (labelInDb == null)
                {
                    labelInDb = new Label()
                    {
                        Text = label
                    };

                    this.Data.Labels.Add(labelInDb);
                    this.Data.SaveChanges();
                }

                labelsInDb.Add(labelInDb);
            }

            var snippet = new Snippet()
            {
                Title = model.Title,
                Description = model.Description,
                Code = model.Code,
                CreationTime = DateTime.Now,
                LanguageId = this.Data.Languages.All().First(l => l.Name == model.Language).Id,
                Labels = labelsInDb,
                AuthorId = userId
            };

            this.Data.Snippets.Add(snippet);
            this.Data.SaveChanges();

            return RedirectToAction("Details", new { id = snippet.Id });
        }

        [Authorize]
        public ActionResult SendEdit(int id, string title)
        {
            var languages = new List<SelectListItem>();

            languages.AddRange(this.Data.Languages.All()
                .Select(l => new SelectListItem()
                {
                    Text = l.Name
                }));

            this.ViewBag.Languages = languages;
            this.ViewBag.Id = id;
            this.ViewBag.Title = title;

            return View(new SnippetBindingModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SnippetBindingModel model, int id)
        {
            var snippet = this.Data.Snippets.All()
                .First(s => s.Id == id);

            snippet.Title = model.Title;
            snippet.Description = model.Description;
            snippet.Code = model.Code;
            snippet.LanguageId = this.Data.Languages.All().First(l => l.Name == model.Language).Id;

            foreach (var label in snippet.Labels.ToList())
            {
                snippet.Labels.Remove(label);
            }

            this.Data.SaveChanges();

            var labels = model.Labels.Split(';').Select(l => l.Trim()).ToList();
            var labelsInDb = new List<Label>();

            foreach (var label in labels)
            {
                var labelInDb = this.Data.Labels.All()
                    .FirstOrDefault(l => l.Text == label);

                if (labelInDb == null)
                {
                    labelInDb = new Label()
                    {
                        Text = label
                    };

                    this.Data.Labels.Add(labelInDb);
                    this.Data.SaveChanges();
                }

                labelsInDb.Add(labelInDb);
            }

            snippet.Labels = labelsInDb;

            this.Data.SaveChanges();

            return RedirectToAction("Details", new { id = snippet.Id });
        }

        public ActionResult Search(string searchString)
        {
            var snippets = this.Data.Snippets.All()
                .Where(s => s.Title.Contains(searchString) || s.Labels
                    .Any(l => l.Text.Contains(searchString)))
                .ToList();
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);

            return View(snippetModels);
        }
    }
}