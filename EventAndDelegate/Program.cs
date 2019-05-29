using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostsLibrary;

namespace EventAndDelegate
{
    class Program
    {
        enum CommentModify { write, delete};
        static void Main(string[] args)
        {
            Posts posts = new Posts("내일로 여행", 103);

            posts.CommentCountChanged += Posts_CommentCountChanged;

            Console.WriteLine("댓글 작성 : 0, 댓글 삭제 : 1");
            int input = int.Parse(Console.ReadLine());
            CommentModify commenModify = (CommentModify)input;
            Console.WriteLine("게시물 댓글 수(before) : " + posts.CommentCount);
            if(commenModify == CommentModify.write)
                posts.IncreaseCommentsNumber();
            else if(commenModify == CommentModify.delete)
                posts.DecreaseCommentsNumber();
            Console.WriteLine("게시물 댓글 수(after) : " + posts.CommentCount);
        }

        private static void Posts_CommentCountChanged(object sender, Posts.CommentCountChangedEventArgs e)
        {
            Console.WriteLine($"댓글수가 {e.OldCommentCount}에서 {e.NewConnentCount}로 변경되었습니다.");
        }
    }
}
