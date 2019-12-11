using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    #region T2
    public class ApuestasUsuarioEmail
    {
        public ApuestasUsuarioEmail(string equipoL, string equipoV, float idmercado, char tipoA, float cuota, float dinero)
        {
            this.equipoL = equipoL;
            this.equipoV = equipoV;
            this.idmercado = idmercado;
            this.tipoA = tipoA;
            this.cuota = cuota;
            this.dinero = dinero;
        }

        //1-Crear Get-Set
        //2-Crear Contructor apartir de los get-set


        public string equipoL { get; set; }
        public string equipoV { get; set; }
        public float idmercado { get; set; }
        public char tipoA { get; set; }
        public float cuota { get; set; }
        public float dinero { get; set; }
    }

    // EJERCICIO 2
    public class ApuestasMercado
    {
        public ApuestasMercado(string email, float idmercado, char tipoA, float cuota, float dinero)
        {
            Email = email;
            this.idmercado = idmercado;
            this.tipoA = tipoA;
            this.cuota = cuota;
            this.dinero = dinero;
        }


        //1-Crear Get-Set
        //2-Crear Contructor apartir de los get-set


        public string Email { get; set; }
        
        public float idmercado { get; set; }
        public char tipoA { get; set; }
        public float cuota { get; set; }
        public float dinero { get; set; }
    }




    #endregion

    #region SACO
    public class Apuesta

    {
        public Apuesta(int idApuesta, float dinero, float cuota, char tipo, int fK_UsuarioId, int fK_MercadoId, string email)
        {
            IdApuesta = idApuesta;
            Dinero = dinero;
            Cuota = cuota;
            Tipo = tipo;
            FK_UsuarioId = fK_UsuarioId;
            FK_MercadoId = fK_MercadoId;
            Email = email;
        }

        //constructor para traer los datos solo de tabla apuestas


        public int IdApuesta { get; set; }
        public float Dinero { get; set; }
        public float Cuota { get; set; }
        public char Tipo { get; set; }
        public int FK_UsuarioId { get; set; }
        public int FK_MercadoId { get; set; }
        public string Email { get; set; }
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
    #endregion
}