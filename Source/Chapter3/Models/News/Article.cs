using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter3.Models.News
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string Headline { get; set; }
        public string Byline { get; set; }
        public string Lead { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
        public string PublishedBy { get; set; }
    }
}