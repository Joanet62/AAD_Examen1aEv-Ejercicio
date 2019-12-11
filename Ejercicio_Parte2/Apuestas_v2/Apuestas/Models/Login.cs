using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    public class Login
    {
        public Login(int idUsuario, string dNI, string email, string nombre, string apellidos)
        {
            IdUsuario = idUsuario;
            DNI = dNI;
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
        }
        public Login()
        {

        }
        [Key]
        public int IdUsuario { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<Apuesta> Apuesta { get; set; }
        public Cuentas cuenta { get; set; }
        //public string IdPartido { get; set; }
    } 
    public class DatosLogin
    {
        public string DNI { get; set; }
        public string Email { get; set; }
    }
}