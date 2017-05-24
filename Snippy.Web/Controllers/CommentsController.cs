namespace Snippy.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Snippy.Data.UnitOfWork;
    using Snippy.Models;
    using Snippy.Web.Models.ViewModels;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class CommentsController : BaseController
    {
        public CommentsController(ISnippyData data)
            : base(data)
        {
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Add(int id, string content)
        {
            var userId = this.User.Identity.GetUserId();
            var comment = new Comment()
            {
                Content = content,
                CreationTime = DateTime.Now,
                Author = this.Data.Users.All().First(u => u.Id == userId)
            };

            this.Data.Snippets.All()
                .First(s => s.Id == id)
                .Comments
                .Add(comment);
            this.Data.SaveChanges();

            var commentModel = Mapper.Map<Comment, SnippetCommentViewModel>(comment);

            return PartialView("DisplayTemplates/SnippetCommentViewModel", commentModel);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var comment = this.Data.Comments.All()
                .First(c => c.Id == id);
            var commentModel = Mapper.Map<Comment, CommentViewModel>(comment);

            this.ViewBag.Id = id;

            return View(commentModel);
        }

        [Authorize]
        public ActionResult DeleteComment(int id, int snippetId)
        {
            this.Data.Comments.Remove(this.Data.Comments.All().First(c => c.Id == id));
            this.Data.SaveChanges();

            return RedirectToAction("Details", "Snippets", new { id = snippetId });
        }
    }
}