namespace Snippy.Models
{
    using System;
    using System.Collections.Generic;

    public class Snippet
    {
        private ICollection<Label> labels;
        private ICollection<Comment> comments;

        public Snippet()
        {
            this.Labels = new HashSet<Label>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime CreationTime { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Label> Labels
        {
            get
            {
                return this.labels;
            }

            set
            {
                this.labels = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}
