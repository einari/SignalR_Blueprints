using System.Collections.Generic;
using Chapter3.DAL;
using Chapter3.Models.News;
using Microsoft.AspNet.SignalR;

namespace Chapter3.Hubs
{
    public class ArticleHub : Hub
    {
        ArticleContext _articleContext;
        public ArticleHub()
        {
            _articleContext = new ArticleContext();
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