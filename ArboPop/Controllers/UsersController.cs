using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArboPop.Connections;
using ArboPop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArboPop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserRepo _repository;

        public UsersController(UserRepo repository)
        {
            _repository = repository;
        }

        //Get a single user by uid
        //[HttpGet("{uid}")]
        //public ActionResult GetUser(string uid)
        //{
        //    var user = _repository.GetUser(uid);

        //    return Ok(user);
        //}
    }
}