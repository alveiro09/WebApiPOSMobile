using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPOSMobile.Models;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPOSMobile.Controllers
{
    [Route("api/Transaccion")]
    public class TransaccionController : Controller
    {
        DataAccessTransaccion objds;

        public TransaccionController(DataAccessTransaccion d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Transaccion> Get()
        {
            return objds.GetTransaccions();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var Transaccion = objds.GetTransaccion(new ObjectId(id));
            if (Transaccion == null)
            {
                return NotFound();
            }
            return new ObjectResult(Transaccion);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Transaccion p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Transaccion p)
        {
            var recId = new ObjectId(id);
            var Transaccion = objds.GetTransaccion(recId);
            if (Transaccion == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Transaccion = objds.GetTransaccion(new ObjectId(id));
            if (Transaccion == null)
            {
                return NotFound();
            }

            objds.Remove(Transaccion.Id);
            return new OkResult();
        }
    }
}
