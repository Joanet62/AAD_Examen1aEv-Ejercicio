using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    public class Mercado
    {
        public Mercado(float idMercado, float cuotaOver, float cuotaUnder, float dineroOver, float dineroUnder, int idPartido)
        {
            IdMercado = idMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            this.idPartido = idPartido;
        }
        public Mercado()
        {

        }
        [Key]
            public float IdMercado { get; set; }
            public float CuotaOver { get; set; }
            public float CuotaUnder { get; set; }
            public float DineroOver { get; set; }
            public float DineroUnder { get; set; }

        //dependiente||| primero deber crearse la tabla partido antes de mercado
        public int idPartido { get; set; }//Indicamos que tiene un idpartido
        public Partido Partido { get; set; }//aqui decimos que idpartido viene de la clase partido
        //
        public List<Apuesta> Apuesta { get; set; }

    }

    //DTO
    public class MercadoDTO
    {
        public MercadoDTO(float idmercado, float CuotaO, float CuotaU)
        {
            idMercado = idmercado;
            CuotaOver = CuotaO;
            CuotaUnder = CuotaU;
        }

        public float idMercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }


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
  
         


}
  
