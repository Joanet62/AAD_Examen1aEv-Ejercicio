using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apuestas.Models;

namespace Apuestas.Controllers
{
    // EJERCICIO 1
    public class LeaguesController : ApiController
    {
        // GET: api/Leagues
        public IEnumerable<League> Get()
        {
            var repo = new LeaguesRepository();
            List<League> League = repo.GetLeagues();

            return League;
        }

        // GET: api/Leagues/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Leagues
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Leagues/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Leagues/5
        public void Delete(int id)
        {
        }
    }
}
