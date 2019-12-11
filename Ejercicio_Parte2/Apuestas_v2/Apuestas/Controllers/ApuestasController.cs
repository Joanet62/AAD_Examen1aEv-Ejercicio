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
    [RoutePrefix("api/Apuestas")]
    public class ApuestasController : ApiController
    {
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

        // GET: api/Apuestas
      //  [Authorize(Roles ="Admin")]
        //public IEnumerable<Apuesta> Get()
        //{
        //    //var repo = new ApuestasRepository();
        //    //List<Apuestas5datos> apuestas = repo.GetApuestas();
        //    //return apuestas;
        //    var repo = new ApuestasRepository();
        //    List<Apuesta> apuestas = repo.RetrieveDTO();
        //    return apuestas;
        //}
        //EA5-12_3
        public IEnumerable<Apuesta> Get()
        {
            //var repo = new ApuestasRepository();
            //List<Apuestas5datos> apuestas = repo.GetApuestas();
            //return apuestas;
            var repo = new ApuestasRepository();
            // List<ApuestaDTO2> apuestas = repo.RetrieveDTO();
            List<Apuesta> apuestas = repo.GetApuestas();
            return apuestas;
        }
        //EA6-4
        [HttpGet]
        [Route("GetApuestasMercados")]
        public IEnumerable<Apuesta> GetApuestasMercados()
        {
            //var repo = new ApuestasRepository();
            //List<Apuestas5datos> apuestas = repo.GetApuestas();
            //return apuestas;
            var repo = new ApuestasRepository();
            // List<ApuestaDTO2> apuestas = repo.RetrieveDTO();
            List<Apuesta> apuestas = repo.GetApuestasMercado();
            return apuestas;
        }
        //EA6-8
        [HttpGet]
        [Route("GetApuestaDTO")]
        public IEnumerable<ApuestaDTO2> GetApuestaDTO()
        {
            //var repo = new ApuestasRepository();
            //List<Apuestas5datos> apuestas = repo.GetApuestas();
            //return apuestas;
            var repo = new ApuestasRepository();
            List<ApuestaDTO2> apuestas = repo.RetrieveApuestas();
           // List<Apuesta> apuestas = repo.GetApuestasMercado();
            return apuestas;
        }
        //AE5-12_5
        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
             var repo = new ApuestasRepository();
               Apuesta a = repo.GetApuesta(id);
            return a;
        }
        //EA6-2
        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            // var reposMercado = new MercadosRepository();
            //var repo = new ApuestasRepository();

            ////Vamos a ejecutar la fórmula para dar el valor de la cuota
            ////consultar el valor actual de la cuota
            ////Mercado mercado = new Mercado();
            //var mercado = reposMercado.GetCuota(Convert.ToDecimal(apuesta.FK_MercadoId)); 
            //float probalidad = 0;
            //if(apuesta.Tipo.ToString()=="O")
            //{
            //    probalidad = mercado.DineroOver / (mercado.DineroOver+mercado.DineroUnder);
            //    apuesta.Cuota =(float)((1 / probalidad) * 0.95);
            //    //update de la cuota en caso que sea Over
            //    reposMercado.UpdateOver(apuesta.FK_MercadoId,apuesta.Cuota);
            //}else if(apuesta.Tipo.ToString() == "U")
            //{
            //    probalidad = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);
            //    apuesta.Cuota = (float)((1 / probalidad) * 0.95);
            //    //update de la cuota en caso que se Under
            //    reposMercado.UpdateUnder(apuesta.FK_MercadoId, apuesta.Cuota);
            //}
            var repo = new ApuestasRepository();
            float mercadoid = apuesta.idmercado;
            
            
            
            float probalidad = 0;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Mercado mercado = context.Mercado.Find(mercadoid);
                if (apuesta.Tipo=='O')
                {
                    probalidad = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
                    apuesta.Cuota = (float)((1 / probalidad) * 0.95);
                    mercado.CuotaOver = apuesta.Cuota;
                    mercado.DineroOver = mercado.DineroOver + apuesta.Dinero;
                }
                else if(apuesta.Tipo=='U')
                {
                    probalidad = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);
                    apuesta.Cuota = (float)((1 / probalidad) * 0.95);
                    mercado.CuotaUnder = apuesta.Cuota;
                    mercado.DineroUnder = mercado.DineroUnder + apuesta.Dinero;
                }
                // context.Entry(mercado).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
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

        [HttpGet]
        [Route("GetApuestasEmail")]
        public IEnumerable<apuestaemail> GetApuestasEmail(string id)
        {
            string email = id;
            var repo = new ApuestasRepository();
            List<apuestaemail> apuestas = repo.GetApuestasemail(email);
            return apuestas;
        }
        // EJERCICIO 3
        //linea 164 y 165 -etiquetas para personalizar un nuevo metodo del controlador, diferente de los que la api-web muestra por defecto
        //linea 12- Previamente debe existir la etiqueta [RoutePrefix("api/Apuestas")] encima del public class
        [HttpGet]
        [Route("GetApuestasNC")]
        public IEnumerable<ApuestaNC> GetApuestasNC(int id)
        {
            
            var repo = new ApuestasRepository();
            List<ApuestaNC> apuestas = repo.GetApuestaNC(id);
            return apuestas;
        }
    }
}
