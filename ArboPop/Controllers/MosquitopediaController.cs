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
    public class MosquitopediaController : ControllerBase
    {
        readonly mosquitoConnections _connections;

        public MosquitopediaController(mosquitoConnections connections)
        {
            _connections = connections;
        }


        //use endpoint https://localhost:#####/api/mosquitopedia/all in url
        [HttpGet("all")]
        public ActionResult GetAllMosquitoes()
        {
            var species = _connections.getAllMosquitoes();

            return Ok(species);
        }

        // use endpoint https://localhost:#####/api/mosquitopedia/{id} in url
        [HttpGet("{id}")]
        public ActionResult GetSingleComplaint(int id)
        {
            var mosquito = _connections.getSingleMosquito(id);

            return Ok(mosquito);
        }

        //    // use endpoint https://localhost:#####/api/Complaints/user/{userId} in url
        //    [HttpGet("user/{userId}")]
        //    public ActionResult GetAllUserOrders(int userId)
        //    {
        //        var complaints = _connections.getAllUserComplaints(userId);

        //        return Ok(complaints);
        //    }

        //    [HttpPost]
        //    public ActionResult AddComplaint(NewComplaint newComplaint)
        //    {
        //        var createdComplaint = _connections.AddNewComplaint(newComplaint);

        //        return Accepted(createdComplaint);

        //    }

        //    // pass id in body
        //    [HttpDelete("{id}")]
        //    public ActionResult DeleteComplaint(int id)
        //    {
        //        var complaint = _connections.DeleteComplaint(id);
        //        return Accepted(complaint);
        //    }
    }
}