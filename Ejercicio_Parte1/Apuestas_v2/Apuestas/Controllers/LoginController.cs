﻿using Apuestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apuestas.Controllers
{
    [AllowAnonymous]

    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        // GET api/Partidos1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Partidos1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Partidos1
        //public void Post([FromBody]DatosLogin Log)
        //{
        //    var repo = new LoginRepository();
        //  Login login=  repo.Authenticate(Log);

        //}
        //especifica el metodo(authenticate) que se llama y tipo de petición(post-get)
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(DatosLogin Log)
        {
            var repo = new LoginRepository();
            Login login = repo.Authenticate(Log);
            if(login!=null)
            {
                return Ok(login);
            }
            else
            {
                return NotFound();
            }
           
        }
        // PUT api/Partidos1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Partidos1/5
        public void Delete(int id)
        {
        }
    }
}