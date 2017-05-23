namespace Snippy.Models
{
    using System.Collections.Generic;

    public class Label
    {
        private ICollection<Snippet> snippets;

        public Label()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Snippet> Snippets
        {
            get
            {
                return this.snippets;
            }

            set
            {
                this.snippets = value;
            }
        }
    }
}
