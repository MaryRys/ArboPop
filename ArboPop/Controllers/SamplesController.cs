using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArboPop.Connections;
using ArboPop.Models.Sample;
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

        //// use endpoint https://localhost:#####/api/Samples/{id} in url
        [HttpGet("{id}")]
        public ActionResult GetSingleSample(int id)
        {
            var sample = _connections.getSingleSample(id);

            return Ok(sample);
        }

        //// use endpoint https://localhost:#####/api/Samples/user/{userId} in url
        [HttpGet("user/{userId}")]
        public ActionResult GetAllUserSamples(int userId)
        {
            var samples = _connections.getAllUserSamples(userId);

            return Ok(samples);
        }

        [HttpPost]
        public ActionResult AddSample(AddNewSample newSample)
        {
            var createdSample = _connections.AddNewSample(newSample);

            return Accepted(createdSample);

        }

        //// pass id in body
        //[HttpDelete("{id}")]
        //public ActionResult DeleteComplaint(int id)
        //{
        //    var complaint = _connections.DeleteComplaint(id);
        //    return Accepted(complaint);
        //}
    }
}