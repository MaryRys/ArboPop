using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArboPop.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArboPop.Models;
using ArboPop.Models.Mosquito;

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

        [HttpPost]
        public ActionResult AddMosquito(AddNewMosquito newMosquito)
        {
            var createdMosquito = _connections.AddNewMosquito(newMosquito);

            return Accepted(createdMosquito);

        }

        //    // pass id in body
        [HttpDelete("{id}")]
        public ActionResult DeleteMosquito(int id)
        {
            var mosquito = _connections.DeleteMosquito(id);
            return Accepted(mosquito);
        }
    }
}