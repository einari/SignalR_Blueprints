using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter2.Models.Forum
{
    public class Thread
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Started { get; set; }
        public string StartedBy { get; set; }
        public DateTime LastPost { get; set; }
        public string LastPostBy { get; set; }
        public int PostCount { get; set; }
    }
}