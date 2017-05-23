using AutoMapper;
using Snippy.Models;
using Snippy.Web.Models.ViewModels;

namespace Snippy.Web.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Snippet, SnippetViewModel>();
                cfg.CreateMap<Label, SnippetLabelViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>()
                    .ForMember("Author", opt => opt.MapFrom(src => src.Author.UserName))
                    .ForMember("SnippetTitle", opt => opt.MapFrom(src => src.Snippet.Title))
                    .ForMember("SnippetId", opt => opt.MapFrom(src => src.Snippet.Id));
                cfg.CreateMap<Label, LabelViewModel>()
                    .ForMember("SnippetsCount", opt => opt.MapFrom(src => src.Snippets.Count));
                cfg.CreateMap<Snippet, SnippetDetailsViewModel>()
                    .ForMember("Language", opt => opt.MapFrom(src => src.Language.Name))
                    .ForMember("AuthorName", opt => opt.MapFrom(src => src.Author.UserName));
                cfg.CreateMap<Label, LabelSnippetsViewModel>();
                cfg.CreateMap<Language, LanguageSnippetsViewModel>();
                cfg.CreateMap<Comment, SnippetCommentViewModel>()
                    .ForMember("Author", opt => opt.MapFrom(src => src.Author.UserName))
                    .ForMember("AuthorId", opt => opt.MapFrom(src => src.Author.Id));
            });
        }
    }
}