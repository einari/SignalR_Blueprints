using System;
using System.Collections.Generic;
using System.Linq;
using Chapter2.DAL;
using Chapter2.Models.Forum;
using Microsoft.AspNet.SignalR;

namespace Chapter2.Hubs.Forum
{
    public class PostHub : Hub
    {
        ForumContext _forumContext;
        public PostHub()
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

        
        public IEnumerable<Post> GetForThread(int threadID)
        {
            var group = ThreadHub.GetGroupNameForThread(threadID);
            Groups.Add(Context.ConnectionId, group);

            return _forumContext.Posts.Where(p => p.ThreadID == threadID);
        }

        public void AddPostToThread(int threadID, string content)
        {
            Thread thread;
            var post = _forumContext.InsertPost(threadID, content, out thread);
            PostAdded(post);
            ThreadHub.ThreadUpdated(thread);
        }

        public static void PostAdded(Post post)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<PostHub>();
            hubContext.Clients.Group(ThreadHub.GetGroupNameForThread(post.ThreadID)).postAdded(post);
        }
    }
}