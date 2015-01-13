using System;
using System.Collections.Generic;
using System.Linq;
using Chapter2.DAL;
using Chapter2.Models.Forum;
using Microsoft.AspNet.SignalR;

namespace Chapter2.Hubs.Forum
{
    public class ThreadHub : Hub, IDisposable
    {
        ForumContext _forumContext;
        
        public ThreadHub()
        {
            _forumContext = new ForumContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _forumContext.Dispose();
            }
            base.Dispose(disposing);
        }


        public void Create(string title, string content)
        {
            var thread = _forumContext.InsertThread(title, content);
            var post = _forumContext.InsertPost(thread.ID, content, out thread);
            
            Clients.All.threadCreated(thread);
            PostHub.PostAdded(post);
        }

        public IEnumerable<Thread>   GetAll()
        {
            var all = _forumContext.Threads.ToArray();
            return all;
        }

        public static string GetGroupNameForThread(int threadID)
        {
            return string.Format("Thread-{0}", threadID);
        }

        public static void ThreadUpdated(Thread thread)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ThreadHub>();
            hubContext.Clients.All.threadUpdated(thread);
        }
    }
}