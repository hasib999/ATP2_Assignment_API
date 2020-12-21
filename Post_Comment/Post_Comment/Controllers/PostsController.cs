using Post_Comment.Attribute;
using Post_Comment.Models;
using Post_Comment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Post_Comment.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        PostRepository postRepository = new PostRepository();
        CommentRepository commentRepository = new CommentRepository();
        [Route(""),BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(postRepository.GetAll());
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var getById = postRepository.Get(id);
            if (getById == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(getById);
            }
        }
        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            postRepository.Insert(post);
            return Created("/api/Posts/" + post.PostId, post);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Post post)
        {
            post.PostId = id;
            postRepository.Update(post);
            return Ok(post);
        }
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            CommentRepository comrepo = new CommentRepository();
            var comm = comrepo.GetCommentsByPost(id);
            if (comm == null)
            {
            }
            else
            {
                foreach (var item in comm)
                {
                    comrepo.Delete(item.CommentId);
                }
            }

            postRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
            
        }


        //Read All Comments For Post

        [Route("{id}/comments")]
        public IHttpActionResult GetCommentsByPostId(int id)
        {
            
            var comments = commentRepository.GetCommentsByPost(id);
            if(comments.Count<=0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(comments);
            }
        }

        [Route("{pid}/Comments/{cid}")]
        public IHttpActionResult Get([FromUri] int pid, [FromUri] int cid)
        {
            var comment = commentRepository.GetSingleComment(pid, cid);
            if (comment.Count <= 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(comment);
            }
        }


        [Route("{id}/Comments")]
        public IHttpActionResult Post([FromUri] int id, Comment comment)
        {
            comment.PostId = id;
            comment.Lid = comment.Lid;

            commentRepository.Insert(comment);
            return Created("/api/Posts/" + comment.PostId + "/Comments", comment);
        }

        [Route("{pid}/Comments/{cid}")]
        public IHttpActionResult Put([FromUri] int pid, [FromUri] int cid, Comment comment)
        {
            comment.PostId = pid;
            comment.CommentId = cid;

            commentRepository.Update(comment);
            return Ok(comment);
        }
        [Route("{pid}/Comments/{cid}")]
        public IHttpActionResult Deletecomment([FromUri] int pid, [FromUri] int cid)
        {
            commentRepository.Delete(cid);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
