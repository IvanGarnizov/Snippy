namespace Snippy.Models
{
    using System.Collections.Generic;

    public class Language
    {
        private ICollection<Snippet> snippets;

        public Language()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

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
