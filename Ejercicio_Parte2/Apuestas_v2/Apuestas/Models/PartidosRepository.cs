using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Apuestas.Models
{
    public class PartidosRepository
    {
        //private MySqlConnection Connect()
        //{
        //    string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta4;Uid=root;password=Joan123456;SslMode=none";          
        //    MySqlConnection con = new MySqlConnection(conexioString);
        //    return con;
        //}

        /*
        // Recuperar 1 registro
        internal Partido Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Partido p = null;

            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3));
                p = new Partido(res.GetInt16(0), res.GetString(1), res.GetString(2), res.GetDouble(3));
            }
        
            con.Close();

            return p;

        }
        */

        //Listado de registros con While
        internal List<Partido> Retrieve()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from partido";

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    Partido p = null;

            //    List<Partido> partidos = new List<Partido>();
            //    while (res.Read())
            //    {
            //        Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetInt32(0));
            //        p = new Partido(res.GetInt16(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetInt32(0));
            //        partidos.Add(p);

            //    }

            //    con.Close();

            //    return partidos;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error de conexión");
            //    return null;
            //}
            //EntityFramework (Realiza lo mismo que la linea 48 a la 76 linea )
            List<Partido> partidos = new List<Partido>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                partidos = context.Partido.ToList();
            }

            return partidos;
            // return null;
        }
        //EA6-5
        //Listado de registros DTO
        internal PartidoDTO ToDTO(Partido e)
        {
           
            return new PartidoDTO(e.EqLocal, e.EqVisitante);
        }
        //EA6-6

        internal List<PartidoDTO> RetrieveDTO()
        {
            List<PartidoDTO> partidos = new List<PartidoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                partidos = context.Partido.Select(P => ToDTO(P)).ToList();
            }

            return partidos;
        }

        

        //traer mercados por partido
        internal List<mercadoPartido> GetmercadoPartido(int idpartido)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT m.idmercado,m.CuotaO,m.CuotaU,p.equipoL,p.equipoV,m.partido_idpartido1 FROM apuesta.mercado m inner join partido p on p.idpartido=m.partido_idpartido1 where partido_idpartido1="+idpartido.ToString();

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    mercadoPartido p = null;

            //    List<mercadoPartido> partidos = new List<mercadoPartido>();
            //    while (res.Read())
            //    {
            //      //  Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2));
            //        p = new mercadoPartido(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2), res.GetString(3), res.GetString(4), res.GetInt32(5));
            //        partidos.Add(p);

            //    }

            //    con.Close();

            //    return partidos;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error de conexión");
            //    return null;
            //}
            return null;
        }

        internal List<mercadoPartido> GetAllmercadoPartido()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT m.idmercado,m.CuotaO,m.CuotaU,p.equipoL,p.equipoV,m.partido_idpartido1 FROM apuesta.mercado m inner join partido p on p.idpartido=m.partido_idpartido1 ";

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    mercadoPartido p = null;

            //    List<mercadoPartido> partidos = new List<mercadoPartido>();
            //    while (res.Read())
            //    {
            //        //  Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2));
            //        p = new mercadoPartido(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2), res.GetString(3), res.GetString(4), res.GetInt32(5));
            //        partidos.Add(p);

            //    }

            //    con.Close();

            //    return partidos;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error de conexión");
            //    return null;
            //}
            return null;
        }
        //AE5-14
        internal void Save(Partido d)
        {
            
            
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Partido.Add(d);
                context.SaveChanges();
            }

        }
        //EA6-9
        internal void Update(Partido d,int id)
        {


            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Partido partido = context.Partido.Find(id);
                partido.EqLocal = d.EqLocal;
                partido.EqVisitante = d.EqVisitante;
                context.SaveChanges();
            }

        }
        //EA6-10
        internal void Delete( int id)
        {


            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Partido partido = context.Partido.Find(id);
                context.Partido.Remove(partido);
                context.SaveChanges();
            }

        }
    }
}