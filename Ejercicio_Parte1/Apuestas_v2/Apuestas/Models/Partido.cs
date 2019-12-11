using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Apuestas.Models
{
    public class Partido
    {
        //Constructor
        public Partido(int idpartido, string equipoL, string equipoV, double mercado, int totalgoles)
        {
            IdPartido = idpartido;
            EqLocal = equipoL;
            EqVisitante = equipoV;
            Mercado = mercado;
            TotalGoles = totalgoles;
        }

        public int IdPartido { get; set; }
        public string EqLocal { get; set; }
        public string EqVisitante { get; set; }
        public double Mercado { get; set; }
        public int TotalGoles { get; set; }

    }


    public class MercadosPartido
    {
        public MercadosPartido(float idMercado, float cuotaO, float cuotaU, float dineroO, float dineroU, int idpartido, int iD, string equipoL, string equipoV, float mercado, int totalGoles)
        {
            IdMercado = idMercado;
            CuotaO = cuotaO;
            CuotaU = cuotaU;
            DineroO = dineroO;
            DineroU = dineroU;
            Idpartido = idpartido;
            ID = iD;
            EquipoL = equipoL;
            EquipoV = equipoV;
            Mercado = mercado;
            TotalGoles = totalGoles;
        }




        //Crear el  Contructor con visual Studio:

        //1-Definir los campos en base a la consula SQL de la Base de datos
        public float IdMercado { get; set; }
        public float CuotaO { get; set; }
        public float CuotaU { get; set; }
        public float DineroO { get; set; }
        public float DineroU { get; set; }
        public int Idpartido { get; set; }
        public int ID { get; set; }
        public string EquipoL { get; set; }
        public string EquipoV { get; set; }
        public float Mercado { get; set; }
        public int TotalGoles { get; set; }
        //2-selecciones todos los campos que se crearon 
        //3-Click derecho  a los campos sombreados
        //4-Seleccionar del Menú QUICK ACTIONS AND REFACTORINGS
        //5-QUICK ACTIONS AND REFACTORINGS >>> Generate Contructor
    }


    //DTO
    //selecciono los campos a mostrar 
    public class PartidoDTO
    {
        
        public PartidoDTO(string eqLocal, string eqVisitante, int idpartido)
        {
            EqLocal = eqLocal;
            EqVisitante = eqVisitante;
            this.idpartido = idpartido;
        }

        public string EqLocal { get; set; }
        public string EqVisitante { get; set; }
        public int idpartido { get; set; }
       
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