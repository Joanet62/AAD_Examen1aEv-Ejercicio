using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    public class LoginRepository
    {
        //private MySqlConnection Connect()
        //{
        //    string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta;Uid=root;password=root;SslMode=none";
        //    MySqlConnection con = new MySqlConnection(conexioString);
        //    return con;
        //}

        internal Login Authenticate(DatosLogin log)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT * FROM apuesta.usuarios where DNI='"+log.DNI+"' AND email='"+log.Email+"'";

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();

            //Login a = null;

            //if (res.Read())
            //{
            //   // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
            //    a = new Login(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4));
            //}

            //con.Close();


            //return a;
            return null;

        }
        //Listado de registros DTO
        internal List<ApuestaDTO> RetrieveDTO()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from apuestas";

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    ApuestaDTO a = null;

            //    List<ApuestaDTO> apuesta = new List<ApuestaDTO>();
            //    while (res.Read())
            //    {
            //        Debug.WriteLine("Recuperado: " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3));
            //        a = new ApuestaDTO(res.GetFloat(1), res.GetFloat(2), res.GetChar(3));
            //        apuesta.Add(a);

            //    }

            //    con.Close();

            //    return apuesta;
            return null;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error de conexión");
            //    return null;
            //}

        }

        internal List<Apuestas5datos> GetApuestas()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select us.email,ap.dinero,ap.cuota,ap.tipo_O_U,mr.idmercado from apuestas ap inner join usuarios us on ap.usuarios_id_usuarios1=us.id_usuarios inner join mercado mr on mr.idmercado = ap.mercado_idmercado1";

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();

            //Apuestas5datos a = null;
            //List<Apuestas5datos> lsi = new List<Apuestas5datos>();
            //if (res.Read())
            //{
            //    // Debug.WriteLine("Recuperado: " + res.GetInt16(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetChar(3) + res.GetInt16(4) + " " + res.GetFloat(5));
            //    a = new Apuestas5datos(res.GetString(0), res.GetFloat(1), res.GetFloat(2), res.GetChar(3), res.GetFloat(4));
            //    lsi.Add(a);
            //}

            //con.Close();

            //return lsi;
            return null;

        }
        internal void Save(Apuesta d)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //string sql = "insert into apuestas (dinero,cuota,tipo_O_U,usuarios_id_usuarios1,mercado_idmercado1) values('" + d.Dinero.ToString() + "','" + d.Cuota.ToString("0.0", CultureInfo.InvariantCulture) + "','" + d.Tipo.ToString() + "','" + d.FK_UsuarioId.ToString() + "','" + d.FK_MercadoId.ToString("0.0", CultureInfo.InvariantCulture) + "');";

            //command.CommandText = sql;

            //Debug.WriteLine("comando " + command.CommandText);
            //try
            //{
            //    con.Open();
            //    command.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine(e.Message);

            //}
            
        }
    }
}