using System;
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
        private readonly DatabaseManager _manager = new DatabaseManager();

        // GET api/proxies?port=&protocol=&anonymity=&country=
        [HttpGet]
        public ActionResult<IEnumerable<Proxy>> Get([FromQuery] int? port, [FromQuery] string protocol, [FromQuery] string anonymity, [FromQuery] string country)
        {
            var proxies = _manager.GetProxies(port, protocol, anonymity, country);
            if (proxies != null)
            {
                return Ok(proxies);
            }
            else
            {
                return NotFound("Invalid parameters.");
            }
        }

        // GET api/proxies/{id}
        [HttpGet("{id}")]
        public ActionResult<Proxy> Get(string id)
        {
            var proxy = _manager.GetProxy(id);
            if (proxy != null)
            {
                return proxy;
            }
            else
            {
                return NotFound("Proxy not found.");
            }
        }

        // POST api/proxies
        [HttpPost]
        public void Post([FromBody] Proxy proxy)
        {
            _manager.AddProxy(proxy);
        }
    }
}
