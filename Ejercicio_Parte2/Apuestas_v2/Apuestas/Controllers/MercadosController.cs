using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apuestas.Models;

namespace Apuestas.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Mercados")]
    public class MercadosController : ApiController
    {
        
        /*
        // GET: api/Mercados
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        */

        //Listado de Registros DTO
        //EA5-12_2
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadosRepository();
            //List<MercadoDTO> mercados = repo.RetrieveDTO();
            List<Mercado> mercados = repo.GetMercados();
            return mercados;
        }

        //EA6-7
        [HttpGet]
        [Route("GetMercadoDTO")]
        public IEnumerable<MercadoDTO> GetMercadoDTO()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
          ///  List<Mercado> mercados = repo.GetMercados();
            return mercados;
        }

        [HttpGet]
        [Route("GetMercadoApuesta")]
        public IEnumerable<MercadoApuesta> GetMercadoApuesta(decimal id)
        {
            decimal idPartido =Convert.ToDecimal( id);
            var repo = new MercadosRepository();
            List<MercadoApuesta> partidos = repo.GetMercadoApuesta(idPartido);
            return partidos;
        }
        //EA5-12_4
        // GET: api/Mercados/5
        [Route("getMercado")]
        public Mercado GetMercado(float id)
        {
             var repo = new MercadosRepository();
               Mercado m = repo.Retrieve(id); 
            return m;
        }
        //AE6-1
        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadosRepository();
            repo.Save(mercado);
        }
        //EA6-3
       
        [Route("getMercadosInlcude")]
        public List<Mercado> GetMercadoInclude()
        {
            var repo = new MercadosRepository();
           List< Mercado> m = repo.GetMercadosInclude();
            return m;
        }
        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
