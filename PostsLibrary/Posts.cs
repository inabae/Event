using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsLibrary
{
    public class Posts
    {
        public string PostsName { get; set; }
        public int CommentCount { get; set; }

        public Posts(string postsName, int commentsNumber)
        {
            PostsName = postsName;
            CommentCount = commentsNumber;
        }
         
        public void IncreaseCommentsNumber()
        {
            int currentCommentsCount = CommentCount;
            CommentCount++;

            OnCommentCountChanged(currentCommentsCount, CommentCount);
        }

        public void DecreaseCommentsNumber()
        {
            int currentCommentsCount = CommentCount;
            CommentCount--;

            OnCommentCountChanged(currentCommentsCount, CommentCount);
        }

        #region CommentCountChanged event things for C# 3.0
        public event EventHandler<CommentCountChangedEventArgs> CommentCountChanged;

        protected virtual void OnCommentCountChanged(CommentCountChangedEventArgs e)
        {
            if (CommentCountChanged != null)
                CommentCountChanged(this, e);
        }

        private CommentCountChangedEventArgs OnCommentCountChanged(int oldCommentCount, int newConnentCount)
        {
            CommentCountChangedEventArgs args = new CommentCountChangedEventArgs(oldCommentCount, newConnentCount);
            OnCommentCountChanged(args);

            return args;
        }

        private CommentCountChangedEventArgs OnCommentCountChangedForOut()
        {
            CommentCountChangedEventArgs args = new CommentCountChangedEventArgs();
            OnCommentCountChanged(args);

            return args;
        }

        public class CommentCountChangedEventArgs : EventArgs
        {
            public int OldCommentCount { get; set; }
            public int NewConnentCount { get; set; }

            public CommentCountChangedEventArgs()
            {
            }

            public CommentCountChangedEventArgs(int oldCommentCount, int newConnentCount)
            {
                OldCommentCount = oldCommentCount;
                NewConnentCount = newConnentCount;
            }
        }
        #endregion
    }
}
