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

        [Route("{id}/Comments")]
        public IHttpActionResult GetCommentsByPostId(int id)
        {

        }
    }
}
