using System.Collections.Generic;

namespace Chapter3.Models.News
{
    public class LandingPageViewModel
    {
        public IEnumerable<Article> TopArticles { get; set; }
        public IEnumerable<Article> OtherArticles { get; set; }
    }
}