using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProxyDB.Database;
using ProxyDB.Models;

namespace ProxyDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxiesController : ControllerBase
    {
        private DatabaseManager _manager = new DatabaseManager();

        // GET api/proxies
        [HttpGet]
        public ActionResult<IEnumerable<Proxy>> Get()
        {
            return Ok(_manager.GetProxies());
        }

        // GET api/proxies/{id}
        [HttpGet("{id}")]
        public ActionResult<Proxy> Get(string id)
        {
            return _manager.GetProxy(id);
        }

        // POST api/proxies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
