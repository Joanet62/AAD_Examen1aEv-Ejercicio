using Apuestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apuestas.Controllers
{
    ////[Authorize]
    //[RoutePrefix("api/Partidos")]
    //public class PartidosController : ApiController
    //{ 
    ///* Recuperar 1 registre
    //    // GET: api/Partidos
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET: api/Partidos/5
    //    public Partido Get(int id)
    //    {
    //        var repo = new PartidosRepository();
    //        Partido d = repo.Retrieve();
    //        return d;
    //    }
    //    */

    //    /*
    //    //Listado de Registros

    //       // GET: api/Partidos
    //       public IEnumerable<Partido> Get()
    //       {
    //        var repo = new PartidosRepository();
    //        List<Partido> partidos = repo.Retrieve();
    //        return partidos;
    //    }
    //    */
    //      //Listado de Registros DTO

    //       // GET: api/Partidos
    //       public IEnumerable<PartidoDTO> Get()
    //    {
    //        var repo = new PartidosRepository();
    //        List<PartidoDTO> partidos = repo.RetrieveDTO();
    //        return partidos;
    //    }
    //    [HttpGet]
    //    [Route("GetMercadoPartido")]
    //    public IEnumerable<mercadoPartido> GetMercadoPartido(int id)
    //    {
    //        int idPartido = id;
    //        var repo = new PartidosRepository();
    //        List<mercadoPartido> partidos = repo.GetmercadoPartido(idPartido);
    //        return partidos;
    //    }
    //    [HttpGet]
    //    [Route("GetMercadoPartidos")]
    //    public IEnumerable<mercadoPartido> GetMercadoPartidos()
    //    {

    //        var repo = new PartidosRepository();
    //        List<mercadoPartido> partidos = repo.GetAllmercadoPartido();
    //        return partidos;
    //    }

    //    // GET: api/Partidos/5
    //    public Partido Get(int id)
    //       {
    //        /* var repo = new PartidosRepository();
    //           Partido d = repo.Retrieve(); */
    //           return null;
    //       }



    //// POST: api/Partidos
    //public void Post([FromBody]Partido partido)
    //    {
    //        var repo = new PartidosRepository();
    //        repo.Save(partido);
    //    }

    //    // PUT: api/Partidos/5
    //    public void Put(int id, [FromBody]string value)
    //    {

    //    }

    //    // DELETE: api/Partidos/5
    //    public void Delete(int id)
    //    {
    //    }
    //}

    //cambiar el nombre de la clase ValuesController a  PartidosController

    public class PartidosController : ApiController
    {
        //C
        // GET api/Partidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Partidos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Partidos
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Partidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Partidos/5
        public void Delete(int id)
        {
        }
    }
}
