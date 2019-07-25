using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArboPop.Connections;

namespace ArboPop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        readonly ComplaintsConnections _connections;

        public ComplaintsController(ComplaintsConnections connections)
        {
            _connections = connections;
        }

        [HttpGet("all")]
        public ActionResult GetAllComplaints()
        {
            var complaints = _connections.getAllComplaints();

            return Ok(complaints);
        }
    }
}