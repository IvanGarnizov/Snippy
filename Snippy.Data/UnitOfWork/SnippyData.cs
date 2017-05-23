namespace Snippy.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Models;

    using Repositories;

    public class SnippyData : ISnippyData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;

        public SnippyData()
            : this(new SnippyContext())
        {
        }

        public SnippyData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Snippet> Snippets
        {
            get { return this.GetRepository<Snippet>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Language> Languages
        {
            get { return this.GetRepository<Language>(); }
        }

        public IRepository<Label> Labels
        {
            get { return this.GetRepository<Label>(); }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}