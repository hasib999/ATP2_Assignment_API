using Post_Comment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Post_Comment.Repositories
{
    public class LoginRepository : Repository<Login>
    {
        public List<Login> Login(int username, string password)
        {
            return GetAll().Where(x => x.Lid == username && x.Password == password).ToList();
        }
    }
}