using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    public class Mercado
    {


        public Mercado()
        {

        }

        public Mercado(decimal idMercado, float cuotaOver, float cuotaUnder, float dineroOver, float dineroUnder, int idPartido, int iD)
        {
            IdMercado = idMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            IdPartido = idPartido;
            ID = iD;
        }

        public decimal IdMercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }
        public float DineroOver { get; set; }
        public float DineroUnder { get; set; }
        public int IdPartido { get; set; }
        public int ID { get; set; }
    }

    //DTO
    public class MercadoDTO
    {
        public MercadoDTO(float mercado, float cuotaOver, float cuotaUnder, int idMercado)
        {
            this.mercado = mercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            this.idMercado = idMercado;
        }

        public float mercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }
        public int idMercado { get; set; }


    }

    public class MercadoApuesta
    {
        public MercadoApuesta(string email, decimal idMercado, char tipo, float cuota, float dinero)
        {
            this.email = email;
            IdMercado = idMercado;
            Tipo = tipo;
            Cuota = cuota;
            Dinero = dinero;
        }

        public string email { get; set; }
        public decimal IdMercado { get; set; }
        public char Tipo { get; set; }
        public float Cuota { get; set; }

        public float Dinero { get; set; }

    }
    //para un partido(Evento) Recuperar todos sus mercados con los datos ,mercado,Cuota Over,Cuota Under,(AE4-1)
    public class MercadosCuotaPartido{
        public MercadosCuotaPartido(float mercado, float cuotaO, float cuotaU, int idMercado)
        {
            Mercado = mercado;
            CuotaO = cuotaO;
            CuotaU = cuotaU;
            this.idMercado = idMercado;
        }
        
        //se crear los campos que necesitamos 
        //Get;Set;
        //1-crear los get y set 
        //2-en base a los get y set generar el contructor

        public float Mercado { get; set; }
        public float CuotaO { get; set; }
        public float CuotaU { get; set; }
        public int idMercado { get; set; }






    }
  
         


}
  
