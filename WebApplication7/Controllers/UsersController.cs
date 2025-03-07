using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IHttpActionResult Get()
        {
            using (var db = new ZCharge_PlanEntities())
            {
                var users = db.User.Select(u => new
                {
                    u.ID,
                    u.Sex,
                    u.Level_id,
                    u.Username,
                    u.Birthday,
                    u.Password,
                    u.Name,
                    u.Status,
                }).ToList();
                return Ok(users);
            }
        }

        // GET: api/Users/5
        [Route("Login")]
        public IHttpActionResult GetLogin(string username,string password)
        {
            using (var db = new ZCharge_PlanEntities())
            {
                var user = db.User
                    .Where(u => u.Username == username && u.Password == password)
                    .Select(u => new
                    {
                        u.Name,
                        u.Status
                    }).FirstOrDefault();
                

                if (user != null)
                {
                    var Status = user.Status;
                    switch (Status)
                    {
                        case 0:
                            return Content(HttpStatusCode.Unauthorized, new { message = "帳號已停用" });
                        break;
                            case 1:
                            return Ok(user);
                            break;


                    }
                    return Ok(user); // 返回 200 OK，並包含用戶資訊
                }
                else
                {
                    return Content(HttpStatusCode.Unauthorized, new { message = "Invalid username or password" });
                }
            }
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
           
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
