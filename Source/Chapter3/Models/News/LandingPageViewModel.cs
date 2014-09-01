using System.Collections.Generic;

namespace Chapter3.Models.News
{
    public class LandingPageViewModel
    {
        public IEnumerable<Article> TopTwo { get; set; }
        public IEnumerable<Article> AfterTopTwo { get; set; }
    }
}