using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apuestas.Models;

namespace Apuestas.Controllers
{
    //AE4-6
   // [Authorize]
    [RoutePrefix("api/Apuestas")]
    public class ApuestasController : ApiController
    {
        #region SACO
        /*
        // GET: api/Apuestas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestasRepository();
            Apuesta a = repo.Retrieve();
            return a;
        }
        */

        //Listado de Registros DTO

       

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            /* var repo = new MercadosRepository();
               Apuesta a = repo.Retrieve(); */
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var reposMercado = new MercadosRepository();
            var repo = new ApuestasRepository();

            //Vamos a ejecutar la fórmula para dar el valor de la cuota
            //consultar el valor actual de la cuota
            //Mercado mercado = new Mercado();
            var mercado = reposMercado.GetCuota(apuesta.FK_MercadoId); 
            float probalidad = 0;
            if(apuesta.Tipo.ToString()=="O")
            {
                probalidad = mercado.DineroOver / (mercado.DineroOver+mercado.DineroUnder);
                apuesta.Cuota =(float)((1 / probalidad) * 0.95);
                //update de la cuota en caso que sea Over
                reposMercado.UpdateOver(apuesta.FK_MercadoId,apuesta.Cuota);
            }else if(apuesta.Tipo.ToString() == "U")
            {
                probalidad = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);
                apuesta.Cuota = (float)((1 / probalidad) * 0.95);
                //update de la cuota en caso que se Under
                reposMercado.UpdateUnder(apuesta.FK_MercadoId, apuesta.Cuota);
            }

            repo.Save(apuesta);

        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
        #endregion
        
        #region T2
        //AE4-6
        // GET: api/Apuestas       
        public IEnumerable<Apuestas5datos> Get()
        {
            var repo = new ApuestasRepository();
            List<Apuestas5datos> apuestas = repo.GetApuestas();
            return apuestas;
        }

        //AE4-2
        [HttpGet]
        [Route("GetApuestasEmail")]
        public IEnumerable<ApuestasUsuarioEmail> GetApuestasEmail(string id)
        {
            string email = id;
            var repo = new ApuestasRepository();
            List<ApuestasUsuarioEmail> apuestas = repo.ApuestasUsuario(email);
            return apuestas;
        }
        //AE4-3

        // EJERCICIO 2
        [HttpGet]
        [Route("GetApuestasMercado")]
        //[Authorize(Roles = "Admin")]//AE4-7
        public IEnumerable<ApuestasMercado> GetApuestasMercado(int id)
        {            
            var repo = new ApuestasRepository();
            List<ApuestasMercado> apuestas = repo.ApuestasMercado(id);
            return apuestas;
        }


        #endregion
    }
}
