using System;
using System.Linq;
using System.Web.Http;
using WhosAtDinner.Repository.Services;
using WhoseAtDinner.Models.Models;

namespace WhosAtDinner.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            try
            {
                IQueryable<User> users = UserService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetUser(Guid uid)
        {
            try
            {
                User user = UserService.GetUser(uid);
                return Ok(user);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            try
            {
                UserService.AddUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        public IHttpActionResult UpdateUser(User user)
        {
            try
            {
                UserService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}