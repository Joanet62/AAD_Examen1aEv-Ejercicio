using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    // EJERCICIO 1
    public class League
    {
        public League(string short_name, string name)
        {
            Abreviatura = short_name;
            Nombre = name;
        }

        public string Abreviatura { get; set; }
        public string Nombre { get; set; }

    }
}