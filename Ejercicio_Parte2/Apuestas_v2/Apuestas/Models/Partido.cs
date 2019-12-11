using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Apuestas.Models
{
    public class Partido
    {
        public Partido(int idPartido, string eqLocal, string eqVisitante, double ctMercado, int totalGoles)
        {
            IdPartido = idPartido;
            EqLocal = eqLocal;
            EqVisitante = eqVisitante;
            this.ctMercado = ctMercado;
            TotalGoles = totalGoles;
            
        }
        public Partido()
        {

        }


        //Constructor

        [Key]
        public int IdPartido { get; set; }
        
        public string EqLocal { get; set; }
        public string EqVisitante { get; set; }
        
        public double ctMercado { get; set; }
        public int TotalGoles { get; set; }
        public List<Mercado> Mercado { get; set; }
       
        ////depediente
        //public int Mercadoid { get; set; }
        //public Mercado Mercado { get; set; }

    }

    //DTO
    public class PartidoDTO
    {
        public PartidoDTO(string eqLocal, string eqVisitante)
        {
            EqLocal = eqLocal;
            EqVisitante = eqVisitante;
          
        }

        public string EqLocal { get; set; }
        public string EqVisitante { get; set; }
     

    }
    public class mercadoPartido{
        public mercadoPartido(float mercado, float cuotaO, float cuotaU, string eqLocal, string eqVisitante, int idPartido)
        {
            Mercado = mercado;
            CuotaO = cuotaO;
            CuotaU = cuotaU;
            EqLocal = eqLocal;
            EqVisitante = eqVisitante;
            IdPartido = idPartido;
        }

        public float Mercado { get; set; }
        public float CuotaO { get; set; }
        public float CuotaU { get; set; }
       
        public string EqLocal { get; set; }
        public string EqVisitante { get; set; }
        public int IdPartido { get; set; }



    }
}



//New mercado
/*
namespace mercado.Models
{
    public class mercado
    {

        public mercado(decimal idmercado, float CuotaO, float CuotaU, decimal DineroO, decimal DineroU, int partido_idpartido)
        {
            IdMercado = idmercado;
            CuotaOver = CuotaO;
            CuotaUnder = CuotaU;
            DineroOver = DineroO;
            DineroUnder = DineroU;
            IdPartido = partido_idpartido;
        }

        public decimal IdMercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }
        public decimal DineroOver { get; set; }
        public decimal DineroUnder { get; set; }
        public int IdPartido { get; set; }
    }
}
*/