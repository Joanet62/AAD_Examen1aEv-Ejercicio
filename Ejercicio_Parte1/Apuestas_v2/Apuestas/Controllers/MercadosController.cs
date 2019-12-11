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



        #region SACO
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
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
        [HttpGet]
        [Route("GetMercadosPartido")]
        public IEnumerable<MercadoDTO> GetMercadosPartido(int id)
        {
            int idPartido = id;
            var repo = new MercadosRepository();
            List<MercadoDTO> partidos = repo.RetrieveDTOMP(idPartido);
            return partidos;
        }
        #endregion
        #region T2
        // GET: api/Mercados/5
        public IEnumerable<MercadosCuotaPartido> Get(int id)
        {
             var repo = new MercadosRepository();
               List<MercadosCuotaPartido> ListaMercadosPartido = repo.MercadosCuotaPartido(id); 
            return ListaMercadosPartido;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
