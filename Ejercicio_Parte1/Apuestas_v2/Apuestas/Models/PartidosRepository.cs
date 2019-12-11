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
        private MySqlConnection Connect()
        {
            string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(conexioString);
            return con;
        }

        #region Metodos PartidoController

        //GET de Partido1Controller (TODOS)
        internal List<Partido> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Partido p = null;

                List<Partido> partidos = new List<Partido>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetInt32(0));
                    p = new Partido(res.GetInt16(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetInt32(0));
                    partidos.Add(p);

                }

                con.Close();

                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }


        // GET de Partido1Controller(UNO)
        internal Partido Retrieve(int idpartido)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido where idpartido=" + idpartido;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Partido p = null;


                if (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetInt32(0));
                    p = new Partido(res.GetInt16(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetInt32(0));


                }

                con.Close();

                return p;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }


        //POST de Partido1Controller
        internal void Save(Partido d)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            //command.CommandText = "insert into partido (equipoL, equipoV, mercado, TotalGoles) values (' "+d.EqLocal+ "',' " +d.EqVisitante+ "'," +d.Mercado+ "," +d.TotalGoles+ ")";
            command.CommandText = "Insert Into partido (equipoL, equipoV, mercado, TotalGoles) values ('" + d.EqLocal + "', '" + d.EqVisitante + "', '" + d.Mercado.ToString() + "' , '" + d.TotalGoles.ToString() + "')";
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message);

            }
        }

        //PUT de Partido1Controller
        internal void Update(Partido d, int idpartido)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update apuesta.partido set equipoL='" + d.EqLocal.ToString() + "',equipoV='" + d.EqVisitante.ToString() + "',mercado='" + d.Mercado + "',TotalGoles='" + d.TotalGoles + "' where idpartido=" + idpartido;
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message);

            }
        }


        //DELETE de Partido1Controller
        internal void Delete( int idpartido)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "delete from apuesta.partido where idpartido="+idpartido.ToString();
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message);

            }
        }


        //GET de Partido1Controller >> GetMercadosPartido (Mercados de un Partido)
        //List entre flechas se debe indicar el nuevo modelo creado en archivo Partido
        
        internal List<MercadosPartido> MercadosPartido(int idpartido)
        {

            //0-clase MercadosPartido (en archivo partido .cs)|| para ir buscar la clase click sobre el nombre de la clase ,Boton derecho >> Ir a la definición
            
            //1 - (public private internal) 
            ///2 -int ,list,string ,float,booelan 
            //3-Nombre del metodo 
            //4 -parentesis() y/o parametro si requiere 
            //5 -{}

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM apuesta.mercado  a inner join partido p on p.idpartido=a.partido_idpartido1 where p.idpartido="+idpartido;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                //RES es el resultado de la tabla que nos trae la base datos
                MercadosPartido p = null;

                List<MercadosPartido> partidos = new List<MercadosPartido>();
                while(res.Read())
                {
                    // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetInt32(0));
                    //pasarle los campos del contructor de la clase MercadosPartido
                    //poniendo sobre la instacia(new MercadosPartido ) te muestra los tipos de datos que recibe el contructor
                    
                    p = new MercadosPartido(res.GetFloat(0),res.GetFloat(1),res.GetFloat(2),res.GetFloat(3),res.GetFloat(4),res.GetInt32(7),res.GetInt32(6),res.GetString(8),res.GetString(9),res.GetFloat(10),res.GetInt32(11));
                    partidos.Add(p);

                }

                con.Close();

                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        internal List<PartidoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                PartidoDTO p = null;

                List<PartidoDTO> partidos = new List<PartidoDTO>();
                while (res.Read())
                {
                    //Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2));
                    p = new PartidoDTO(res.GetString(1), res.GetString(2), res.GetInt32(0));
                    partidos.Add(p);

                }

                con.Close();

                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        #endregion




        #region Basura
        //Listado de registros DTO
        
        //traer mercados por partido
        //internal List<MercadosPartido> GetmercadoPartido(int idpartido)
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();
        //    command.CommandText = "SELECT m.idmercado,m.CuotaO,m.CuotaU,p.equipoL,p.equipoV,m.partido_idpartido1 FROM apuesta.mercado m inner join partido p on p.idpartido=m.partido_idpartido1 where partido_idpartido1=" + idpartido.ToString();

        //    try
        //    {
        //        con.Open();
        //        MySqlDataReader res = command.ExecuteReader();

        //        MercadosPartido p = null;

        //        List<mercadoPartido> partidos = new List<mercadoPartido>();
        //        while (res.Read())
        //        {
        //            //  Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2));
        //            p = new mercadoPartido(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2), res.GetString(3), res.GetString(4), res.GetInt32(5));
        //            partidos.Add(p);

        //        }

        //        con.Close();

        //        return partidos;
        //    }
        //    catch (MySqlException e)
        //    {
        //        Debug.WriteLine("Error de conexión");
        //        return null;
        //    }

        //}

        //internal List<mercadoPartido> GetAllmercadoPartido()
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();
        //    command.CommandText = "SELECT m.idmercado,m.CuotaO,m.CuotaU,p.equipoL,p.equipoV,m.partido_idpartido1 FROM apuesta.mercado m inner join partido p on p.idpartido=m.partido_idpartido1 ";

        //    try
        //    {
        //        con.Open();
        //        MySqlDataReader res = command.ExecuteReader();

        //        mercadoPartido p = null;

        //        List<mercadoPartido> partidos = new List<mercadoPartido>();
        //        while (res.Read())
        //        {
        //            //  Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2));
        //            p = new mercadoPartido(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2), res.GetString(3), res.GetString(4), res.GetInt32(5));
        //            partidos.Add(p);

        //        }

        //        con.Close();

        //        return partidos;
        //    }
        //    catch (MySqlException e)
        //    {
        //        Debug.WriteLine("Error de conexión");
        //        return null;
        //    }

        //}
        #endregion



    }
}