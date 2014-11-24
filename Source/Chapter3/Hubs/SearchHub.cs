using System.Collections.Generic;
using Chapter3.DAL;
using Chapter3.Models.News;
using Microsoft.AspNet.SignalR;

namespace Chapter3.Hubs
{
    public class SearchHub : Hub
    {
        ArticleContext _articleContext;

        public SearchHub()
        {
            _articleContext = new ArticleContext();
        }

        public IEnumerable<Article> GetArticlesContaining(string phrase)
        {
            return _articleContext.GetArticlesContaining(phrase);
        }
    }
}