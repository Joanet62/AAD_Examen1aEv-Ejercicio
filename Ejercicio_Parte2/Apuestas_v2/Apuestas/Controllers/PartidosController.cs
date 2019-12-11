using Apuestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apuestas.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Partidos")]
    public class PartidosController : ApiController
    {
        /* Recuperar 1 registre
            // GET: api/Partidos
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET: api/Partidos/5
            public Partido Get(int id)
            {
                var repo = new PartidosRepository();
                Partido d = repo.Retrieve();
                return d;
            }
            */

        
        //Listado de Registros
          //EA5-12_1
          //  GET: api/Partidos
           public IEnumerable<Partido> Get()
           {
            var repo = new PartidosRepository();
            List<Partido> partidos = repo.Retrieve();
            return partidos;
        }

        //Listado de Registros DTO

        //EA6-5
        //EA6-6
        [HttpGet]
        [Route("GetPartidosEquipos")]
        public IEnumerable<PartidoDTO> GetPartidosEquipos()
        {
            var repo = new PartidosRepository();
            List<PartidoDTO> partidos = repo.RetrieveDTO();
            return partidos;
        }
        // GET: api/Partidos
        //public IEnumerable<Partido> Get()
        //{
        //    var repo = new PartidosRepository();
        //    List<Partido> partidos = repo.Retrieve();
        //    return partidos;
        //}
        [HttpGet]
        [Route("GetMercadoPartido")]
        public IEnumerable<mercadoPartido> GetMercadoPartido(int id)
        {
            int idPartido = id;
            var repo = new PartidosRepository();
            List<mercadoPartido> partidos = repo.GetmercadoPartido(idPartido);
            return partidos;
        }
        [HttpGet]
        [Route("GetMercadoPartidos")]
        public IEnumerable<mercadoPartido> GetMercadoPartidos()
        {
           
            var repo = new PartidosRepository();
            List<mercadoPartido> partidos = repo.GetAllmercadoPartido();
            return partidos;
        }

        // GET: api/Partidos/5
        public Partido Get(int id)
           {
            /* var repo = new PartidosRepository();
               Partido d = repo.Retrieve(); */
               return null;
           }


        //AE5-14
        //POST: api/Partidos
        public void Post([FromBody]Partido partido)
        {
            var repo = new PartidosRepository();
            repo.Save(partido);
        }
        //EA6-9
        // PUT: api/Partidos/5
        public void Put(int id, [FromBody]Partido partido)
        {
            var repo = new PartidosRepository();
            repo.Update(partido,id);
        }
        //EA6-10
        // DELETE: api/Partidos/5
        public void Delete(int id)
        {
            var repo = new PartidosRepository();
            repo.Delete( id);
        }
    }
}
