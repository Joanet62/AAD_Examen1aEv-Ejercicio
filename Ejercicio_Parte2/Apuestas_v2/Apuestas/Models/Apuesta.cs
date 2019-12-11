using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    public class Apuesta

    {
        public Apuesta(int idApuesta, float dinero, float cuota, char tipo, int idusuario, float idmercado)
        {
            IdApuesta = idApuesta;
            Dinero = dinero;
            Cuota = cuota;
            Tipo = tipo;
            this.idusuario = idusuario;
           
            this.idmercado = idmercado;
           
        }
        public Apuesta()
        {

        }
        [Key]
        public int IdApuesta { get; set; }
        public float Dinero { get; set; }
        public float Cuota { get; set; }
        public char Tipo { get; set; }
        //dependiente de la tabla usuario que se crea antes de tabla apuestas
        public int idusuario { get; set; }
        public Login Usuario { get; set; }
        //dependiente de la tabla mercado que se crea primero
        public float idmercado { get; set; }       
        public Mercado mercado { get; set; }
        //public string Email { get; set; }
    }

    public class Apuestas5datos
    {
        //constructor para unir las tablas: apuestas, usuario, mercado
        public Apuestas5datos(string email, float dinero, float cuota, char tipo_OU, float mercado_idmercado)
        {

            Dinero = dinero;
            Cuota = cuota;
            Tipo = tipo_OU;

            FK_MercadoId = mercado_idmercado;
            Email = email;
        }

        public float Dinero { get; set; }
        public float Cuota { get; set; }
        public char Tipo { get; set; }

        public float FK_MercadoId { get; set; }
        public string Email { get; set; }
    }

    //DTO
    public class ApuestaDTO
    {
        public ApuestaDTO(float dinero, float cuota, char tipo_OU)
        {
            Dinero = dinero;
            Cuota = cuota;
            Tipo = tipo_OU;
        }


        public float Dinero { get; set; }
        public float Cuota { get; set; }
        public char Tipo { get; set; }


    }
    public class ApuestaDTO2
    {
        public ApuestaDTO2(int idusuario, int idpartido, char tipo, float cuota, float dinero)
        {
            this.idusuario = idusuario;
            this.idpartido = idpartido;
            Tipo = tipo;
            Cuota = cuota;
            Dinero = dinero;
        }

        public int idusuario { get; set; }
        public int idpartido { get; set; }
        public char Tipo { get; set; }
        public float Cuota { get; set; }
        public float Dinero { get; set; }
    }

    public class apuestaemail{
        public apuestaemail(int idPartido, string eqLocal, string eqVisitante, float fK_MercadoId, char tipo, float cuota, float dinero)
        {
            IdPartido = idPartido;
            EqLocal = eqLocal;
            EqVisitante = eqVisitante;
            FK_MercadoId = fK_MercadoId;
            Tipo = tipo;
            Cuota = cuota;
            Dinero = dinero;
        }

        public int IdPartido { get; set; }
        public string EqLocal { get; set; }
        public string EqVisitante { get; set; }
        public float FK_MercadoId { get; set; }
        public char Tipo { get; set; }
        public float Cuota { get; set; }
        public float Dinero { get; set; }
       
       
       
     

    }
    // EJERCICIO 3
    public class ApuestaNC
    {
        public ApuestaNC(string nombre, float cuota)
        {
            this.nombre = nombre;
            this.cuota = cuota;
        }

        public string nombre { get; set; }
   
        public float cuota { get; set; }
      


    }
}