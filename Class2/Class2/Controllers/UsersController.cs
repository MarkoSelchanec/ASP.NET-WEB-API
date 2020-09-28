using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Class2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Class2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return StaticDb.UserNames;
        }

        [HttpGet("{Id}")]
        public ActionResult<string> GetUserById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can't be lower than 0");
                }
                if (id >= StaticDb.UserNames.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "There is no such user");
                }
                return StaticDb.UserNames[id];
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string user = reader.ReadToEnd();
                    StaticDb.UserNames.Add(user);
                    return StatusCode(StatusCodes.Status201Created, "User created");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                using (StreamReader read = new StreamReader(Request.Body))
                {
                    string idBody = read.ReadToEnd();
                    int id = int.Parse(idBody);
                    StaticDb.UserNames.RemoveAt(id);
                    return StatusCode(StatusCodes.Status204NoContent, "User deleted");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<User>> GetUserObjects()
        {
            return StaticDb.Users;
        }

        [HttpPost("create")]
        public IActionResult PostUserObject()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string jsonBody = reader.ReadToEnd();
                    User newUser = JsonConvert.DeserializeObject<User>(jsonBody);
                    newUser.Id = StaticDb.Users.Count;
                    StaticDb.Users.Add(newUser);
                    return StatusCode(StatusCodes.Status201Created, "User created");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
