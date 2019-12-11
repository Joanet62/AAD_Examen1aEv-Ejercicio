using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Apuestas.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {            
            string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(conexioString);
            return con;
        }
        #region T2
        //AE4-2
        internal List<ApuestasUsuarioEmail> ApuestasUsuario(string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select partido.equipoL,partido.equipoV,mercado.idmercado,apuestas.tipo_O_U,apuestas.cuota,apuestas.dinero from apuestas inner join usuarios on apuestas.usuarios_id_usuarios1=usuarios.id_usuarios inner join mercado on mercado.ID=apuestas.mercado_idmercado1 inner join partido on partido.idpartido=mercado.partido_idpartido1   where usuarios.email='"+ email.ToString() + "'";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestasUsuarioEmail a = null;

                List<ApuestasUsuarioEmail> apuesta = new List<ApuestasUsuarioEmail>();
                while (res.Read())
                {
                    //Debug.WriteLine("Recuperado: " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3));
                    a = new ApuestasUsuarioEmail(res.GetString(0), res.GetString(1), res.GetFloat(2),res.GetChar(3),res.GetFloat(4),res.GetFloat(5));
                    apuesta.Add(a);

                }

                con.Close();

                return apuesta;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        //AE4-3
        internal List<ApuestasMercado> ApuestasMercado(int idmercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            
            // EJERCICIO 2
            command.CommandText = "select usuarios.email,mercado.idmercado,apuestas.tipo_O_U,apuestas.cuota,apuestas.dinero from mercado inner join apuestas on apuestas.mercado_idmercado1=mercado.ID inner join usuarios on apuestas.usuarios_id_usuarios1=usuarios.id_usuarios where apuestas.dinero>100 AND  mercado.ID=" + idmercado;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestasMercado a = null;

                List<ApuestasMercado> apuesta = new List<ApuestasMercado>();
                while (res.Read())
                {
                    //Debug.WriteLine("Recuperado: " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3));
                    a = new ApuestasMercado(res.GetString(0), res.GetFloat(1), res.GetChar(2), res.GetFloat(3), res.GetFloat(4));
                    apuesta.Add(a);

                }

                con.Close();

                return apuesta;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        #endregion
        #region SACO
        internal Apuesta Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Apuesta a = null;

            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
                a = new Apuesta(res.GetInt16(0), res.GetFloat(1), res.GetFloat(2), res.GetChar(3), res.GetInt16(4), res.GetInt32(5),res.GetString(6));
            }

            con.Close();

            return a;

        }
        //Listado de registros DTO
        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;

                List<ApuestaDTO> apuesta = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3));
                    a = new ApuestaDTO(res.GetFloat(1), res.GetFloat(2), res.GetChar(3));
                    apuesta.Add(a);

                }

                con.Close();

                return apuesta;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        
        internal List<Apuestas5datos> GetApuestas()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select us.email,ap.dinero,ap.cuota,ap.tipo_O_U,mr.idmercado from apuestas ap inner join usuarios us on ap.usuarios_id_usuarios1=us.id_usuarios inner join mercado mr on mr.ID = ap.mercado_idmercado1";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Apuestas5datos a = null;
            List<Apuestas5datos> lsi = new List<Apuestas5datos>();
            while (res.Read())
            {
               // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
                a = new Apuestas5datos( res.GetString(0), res.GetFloat(1), res.GetFloat(2), res.GetChar(3), res.GetFloat(4));
                lsi.Add(a);
            }

            con.Close();

            return lsi;

        }
        internal List<apuestaemail> GetApuestasemail(string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select p.idpartido,p.equipoL,p.equipoV,a.mercado_idmercado1,a.tipo_O_U,a.cuota,a.dinero from apuestas a inner join usuarios u on u.id_usuarios=a.usuarios_id_usuarios1 inner join mercado m on m.idmercado=a.mercado_idmercado1 inner join partido p on p.idpartido=m.partido_idpartido1 where u.email='"+ email.ToString()+"'";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            apuestaemail a = null;
            List<apuestaemail> lsi = new List<apuestaemail>();
            while (res.Read())
            {
                // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
                a = new apuestaemail(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetFloat(3), res.GetChar(4), res.GetFloat(5), res.GetFloat(6));
                lsi.Add(a);
            }

            con.Close();

            return lsi;

        }
        internal void Save(Apuesta d)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            string sql= "insert into apuestas (dinero,cuota,tipo_O_U,usuarios_id_usuarios1,mercado_idmercado1) values('" + d.Dinero.ToString() + "','" + d.Cuota.ToString("0.0", CultureInfo.InvariantCulture) + "','" + d.Tipo.ToString() + "','" + d.FK_UsuarioId.ToString() + "','" + d.FK_MercadoId+ "');";
            
            command.CommandText = sql;
            
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
        #endregion
    }
}