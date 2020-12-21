using Post_Comment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Post_Comment.Repositories
{
    public class CommentRepository : Repository<Comment>
    {
        

        public List<Comment> GetCommentsByPost(int id)
        {
            return GetAll().Where(x => x.PostId==id).ToList();
        }
        public List<Comment> GetSingleComment(int pid, int cid)
        {
            return GetAll().Where(x => x.PostId == pid && x.CommentId == cid).ToList();
        }

        //public List<Comment> GetCommentsByCommentId(int pid, int cid)
        //{
        //   return GetAll().Where(x => x.PostId == pid || x.CommentId == cid).ToList();
        //}
    }
}