using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArboPop.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArboPop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        readonly SamplesConnections _connections;

        public SamplesController(SamplesConnections connections)
        {
            _connections = connections;
        }


        //use endpoint https://localhost:#####/api/Samples/all in url
        [HttpGet("all")]
        public ActionResult GetAllSamples()
        {
            var samples = _connections.getAllSamples();

            return Ok(samples);
        }

        //// use endpoint https://localhost:#####/api/Complaints/{id} in url
        //[HttpGet("{id}")]
        //public ActionResult GetSingleComplaint(int id)
        //{
        //    var complaint = _connections.getSingleComplaint(id);

        //    return Ok(complaint);
        //}

        //// use endpoint https://localhost:#####/api/Complaints/user/{userId} in url
        //[HttpGet("user/{userId}")]
        //public ActionResult GetAllUserOrders(int userId)
        //{
        //    var complaints = _connections.getAllUserComplaints(userId);

        //    return Ok(complaints);
        //}

        //[HttpPost]
        //public ActionResult AddComplaint(NewComplaint newComplaint)
        //{
        //    var createdComplaint = _connections.AddNewComplaint(newComplaint);

        //    return Accepted(createdComplaint);

        //}

        //// pass id in body
        //[HttpDelete("{id}")]
        //public ActionResult DeleteComplaint(int id)
        //{
        //    var complaint = _connections.DeleteComplaint(id);
        //    return Accepted(complaint);
        //}
    }
}