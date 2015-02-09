using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Chapter3.Models.News;

namespace Chapter3.DAL
{
    public class ArticleContext : DbContext
    {
        public const int NumberOfTopArticles = 2;

        public DbSet<Article> Articles { get; set; }

        public ArticleContext() : base("DefaultConnection") { }

        public IEnumerable<Article> GetArticles()
        {
            return Articles.OrderByDescending(a => a.PublishedDate);
        }

        public IEnumerable<Article> GetTopArticles()
        {
            return Articles.OrderByDescending(a => a.PublishedDate).Take(NumberOfTopArticles).ToArray();
        }
        public IEnumerable<Article> GetOtherArticles()
        {
            return Articles.OrderByDescending(a => a.PublishedDate).Skip(NumberOfTopArticles).ToArray();
        }

        public Article GetArticle(int id)
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