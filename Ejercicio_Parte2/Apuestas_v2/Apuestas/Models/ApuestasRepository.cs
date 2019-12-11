using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Apuestas.Models
{
    public class ApuestasRepository
    {
        //private MySqlConnection Connect()
        //{
        //    string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta4;Uid=root;password=root;SslMode=none";
        //    MySqlConnection con = new MySqlConnection(conexioString);
        //    return con;
        //}

        internal Apuesta Retrieve()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from apuestas";

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();

            //Apuesta a = null;

            //if (res.Read())
            //{
            //    Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
            //    a = new Apuesta(res.GetInt16(0), res.GetFloat(1), res.GetFloat(2), res.GetChar(3), res.GetInt16(4), res.GetFloat(5));
            //}

            //con.Close();

            //return a;
            return null;
        }
        //AE5-12_3
        internal List<Apuesta> GetApuestas()
        {
            List<Apuesta> apuesta = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //FUNCIONA PARA HACER UN SELECT * FROM 
                apuesta = context.Apuesta.ToList();
            }

            return apuesta;
            //return null;

        }
        //AE6-4
        internal List<Apuesta> GetApuestasMercado()
        {
            List<Apuesta> apuesta = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //FUNCIONA PARA HACER UN SELECT * FROM 
                apuesta = context.Apuesta.Include(p=>p.mercado).ToList();
            }

            return apuesta;
            //return null;

        }
        //AE5-12_5
        internal Apuesta GetApuesta(int idapuesta)
        {
            Apuesta apuesta = new Apuesta();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuesta.Find(idapuesta);
            }

            return apuesta;
            //return null;

        }
        // EJERCICIO 3
        internal ApuestaNC toDTOAPUESTA(Apuesta e)
        {

            return new ApuestaNC(e.Usuario.Nombre +" "+e.Usuario.Apellidos,e.Cuota);
        }
        // EJERCICIO 3
        internal List<ApuestaNC> GetApuestaNC(int apuesta)
        {
            List<ApuestaNC> apuestaNombreCuota = new List<ApuestaNC>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //FUNCIONA PARA HACER UN SELECT * FROM 
                //traer todo la tabla APUESTA que incluya de la tabla USUARIO donde el idapuesta sea igual al apuesta y  solo lo seleccionado en apuestaNC
                //(QUERY EQUIVALENTE AL ENTITYFRAMEWORK) 
                //SELECT apuesta.cuota,usuario.Nombre FROM apuesta inner join usuario ON usuario.idUsuario = apuesta.idusuario where apuesta.IdApuesta = 1
                apuestaNombreCuota = context.Apuesta.Include(p => p.Usuario).Where(P=>P.IdApuesta==apuesta).Select(s=> toDTOAPUESTA(s)).ToList();
            }

            return apuestaNombreCuota;
            //return null;

        }

        internal List<Apuestas5datos> GetApuesta1s()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select us.email,ap.dinero,ap.cuota,ap.tipo_O_U,mr.idmercado from apuestas ap inner join usuarios us on ap.usuarios_id_usuarios1=us.id_usuarios inner join mercado mr on mr.idmercado = ap.mercado_idmercado1";

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();

            //Apuestas5datos a = null;
            //List<Apuestas5datos> lsi = new List<Apuestas5datos>();
            //while (res.Read())
            //{
            //   // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
            //    a = new Apuestas5datos( res.GetString(0), res.GetFloat(1), res.GetFloat(2), res.GetChar(3), res.GetFloat(4));
            //    lsi.Add(a);
            //}

            //con.Close();

            //return lsi;
            return null;

        }
        internal List<apuestaemail> GetApuestasemail(string email)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select p.idpartido,p.equipoL,p.equipoV,a.mercado_idmercado1,a.tipo_O_U,a.cuota,a.dinero from apuestas a inner join usuarios u on u.id_usuarios=a.usuarios_id_usuarios1 inner join mercado m on m.idmercado=a.mercado_idmercado1 inner join partido p on p.idpartido=m.partido_idpartido1 where u.email='"+ email.ToString()+"'";

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();

            //apuestaemail a = null;
            //List<apuestaemail> lsi = new List<apuestaemail>();
            //while (res.Read())
            //{
            //    // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
            //    a = new apuestaemail(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetFloat(3), res.GetChar(4), res.GetFloat(5), res.GetFloat(6));
            //    lsi.Add(a);
            //}

            //con.Close();

            //return lsi;
            return null;

        }
        //EA6-8
        internal ApuestaDTO2 ToDTO(Apuesta e)
        {

            return new ApuestaDTO2(e.idusuario, e.mercado.idPartido, e.Tipo,e.Cuota,e.Dinero);
        }
        //EA6-4||EA6-8
        internal List<ApuestaDTO2> RetrieveApuestas()
        {

            List<ApuestaDTO2> apuestaDTO2s = new List<ApuestaDTO2>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //traer todo la tabla APUESTA que incluya de la tabla MERCADO  solo lo seleccionado en ToDTO()
                apuestaDTO2s = context.Apuesta.Include(p=>p.mercado).Select(d => ToDTO(d)).ToList();
            }

            return apuestaDTO2s;
        }


        //EA6-2
        internal void Save(Apuesta d)
        {
           
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Apuesta.Add(d);
                context.SaveChanges();
            }
        }
       
    }
}