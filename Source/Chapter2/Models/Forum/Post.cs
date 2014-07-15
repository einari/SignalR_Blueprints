using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter2.Models.Forum
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ThreadID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}