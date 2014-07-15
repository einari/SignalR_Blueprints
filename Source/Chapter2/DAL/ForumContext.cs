using System;
using System.Data.Entity;
using Chapter2.Models.Forum;

namespace Chapter2.DAL
{
    public class ForumContext : DbContext
    {
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }

        public Thread InsertThread(string title, string content)
        {
            var currentUser = System.Threading.Thread.CurrentPrincipal.Identity.Name;

            var thread = new Thread
            {
                Title = title,
                Started = DateTime.UtcNow,
                StartedBy = currentUser,
                LastPost = DateTime.UtcNow,
                LastPostBy = currentUser
            };

            Threads.Add(thread);
            SaveChanges();

            return thread;
        }

        public Post InsertPost(int threadID, string content, out Thread thread)
        {
            var currentUser = System.Threading.Thread.CurrentPrincipal.Identity.Name;

            var post = new Post
            {
                ThreadID = threadID,
                Content = content,
                Created = DateTime.UtcNow,
                CreatedBy = currentUser
            };
            Posts.Add(post);

            thread = Threads.Find(threadID);
            thread.LastPost = DateTime.UtcNow;
            thread.LastPostBy = currentUser;
            thread.PostCount++;

            SaveChanges();

            return post;
        }
    }
}