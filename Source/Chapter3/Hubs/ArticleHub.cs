using System;
using System.Collections.Generic;
using Chapter3.DAL;
using Chapter3.Models.News;
using Microsoft.AspNet.SignalR;

namespace Chapter3.Hubs
{
    public class ArticleHub : Hub, IDisposable
    {
        ArticleContext _articleContext;
        public ArticleHub()
        {
            _articleContext = new ArticleContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) 
            {
               _articleContext.Dispose();
            }
            base.Dispose(disposing);
        }


        public IEnumerable<Article> GetArticles()
        {
            return _articleContext.GetArticles();
        }

        [Authorize]
        public void Publish(Article article)
        {
            _articleContext.Insert(article);

            Clients.All.published(article);
        }

    }
}