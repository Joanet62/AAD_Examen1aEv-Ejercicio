using Apuestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apuestas.Controllers
{
    [RoutePrefix("api/Partidos1")]
    public class Partidos1Controller : ApiController
    {
        // GET api/Partidos1
        public IEnumerable<Partido> Get()
        {
            var repo = new PartidosRepository();
            List<Partido> partidos = repo.Retrieve();
            return partidos;
            
        }

        // GET api/Partidos1/5
        
        public Partido Get(int id)
        {
            var repo = new PartidosRepository();
            Partido datosPartido = repo.Retrieve(id);
            return datosPartido;
        }


        //Traer Todos los Mercados de un Derterminado partido
        //crear un Nuevo modelo en el archivo Partido Ya que estamos Convinando 2 tablas y existen nuevos Elementos de la base de datos
        //IEnumerable es como un array que adapta a una lista el model que creaste
        //IEnumerable se usa cuando se trae mas de una linea




        //Las 2 etiquetas entre Corchetes se añaden para que aparesca en el listado de metodos de API.NET 
        //hay que  a la linea 11 y añadir la etiqueta [RoutePrefix("api/Partidos1")] para que reconozca el nuevo metedo en la API.NET 
        // EN EL [RoutePrefix("api/Partidos1")] DEBE LLAMARSE IGUAL QUE EL CONTROLADOR QUE NO AFECTE LOS DEMAS METODOS LINEA 62 
        [HttpGet]
        [Route("GetMercadosPartido")]
        public IEnumerable< MercadosPartido> GetMercadosPartido(int id)
        {
            //Crear nuevo Objeto con la clase donde tengo el metodo             
            //VAR es lo mismo que escribir PartidosRepository(cualquier clase)

            var repo = new PartidosRepository();
            List<MercadosPartido> listaMercadosPartido = repo.MercadosPartido( id);
            return listaMercadosPartido;


        }
        [HttpGet]
        [Route("partidosDTO")]
        public IEnumerable<PartidoDTO> partidosDTO()
        {
            var repo = new PartidosRepository();
            List<PartidoDTO> listaPartidoDTO = repo.RetrieveDTO();
            return listaPartidoDTO;
            

        }





        // POST api/Partidos1
        public void Post([FromBody]Partido partido)
        {
            var repo = new PartidosRepository();
            repo.Save(partido);
        }

        // PUT api/Partidos1/5
        public void Put(int id, [FromBody]Partido partido)
        {
            var repo = new PartidosRepository();
            repo.Update(partido,id);
        }

        // DELETE api/Partidos1/5
        public void Delete(int id)
        {
            PartidosRepository repo = new PartidosRepository();
            repo.Delete(id);
        }
    }
}