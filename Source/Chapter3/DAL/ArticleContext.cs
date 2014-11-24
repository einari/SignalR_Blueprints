using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Chapter3.Models.News;

namespace Chapter3.DAL
{
    public class ArticleContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public IEnumerable<Article> GetArticles()
        {
            return Articles.OrderByDescending(a => a.PublishedDate);
        }

        public IEnumerable<Article> GetTopTwoArticles()
        {
            return Articles.OrderByDescending(a => a.PublishedDate).Take(2);
        }
        public IEnumerable<Article> GetArticlesAfterTopTwo()
        {
            return Articles.OrderByDescending(a => a.PublishedDate).Skip(2);
        }

        public Article GetByID(int id)
        {
            return Articles.Find(id);
        }

        public IEnumerable<Article> GetArticlesContaining(string phrase)
        {
            return Articles.Where(a => a.Headline.Contains(phrase) || a.Body.Contains(phrase));
        }

        public void Insert(Article article)
        {
            var currentUser = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            article.PublishedBy = currentUser;
            article.PublishedDate = DateTime.UtcNow;
            Articles.Add(article);

            SaveChanges();
        }
    }
}