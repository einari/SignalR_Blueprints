using System.Collections.Generic;

namespace Chapter3.Models.News
{
    public class LandingPageModel
    {
        public IEnumerable<Article> TopTwo { get; set; }
        public IEnumerable<Article> AfterTopTwo { get; set; }
    }
}