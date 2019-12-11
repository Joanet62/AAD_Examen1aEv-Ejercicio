using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Apuestas.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(conexioString);
            return con;
        }
        #region T2
        internal List<MercadosCuotaPartido> MercadosCuotaPartido(int idpartido)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT idmercado,CuotaO,CuotaU,ID FROM apuesta.mercado where partido_idpartido1="+idpartido;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadosCuotaPartido m = null;

                List<MercadosCuotaPartido> mercado = new List<MercadosCuotaPartido>();
                while (res.Read())
                {
                 //   Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
                    m = new MercadosCuotaPartido(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2), res.GetInt32(3));
                    mercado.Add(m);

                }

                con.Close();

                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        #endregion
        #region SACO
        internal Mercado Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Mercado m = null;

            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt16(5));
                m = new Mercado(res.GetDecimal(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetInt16(5),res.GetInt32(6));
            }

            con.Close();

            return m;

        }
        //
        internal List<MercadoApuesta> GetMercadoApuesta(decimal idmercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select u.email,m.idmercado,a.tipo_O_U,a.cuota,a.dinero from mercado m inner join apuestas a on a.mercado_idmercado1=m.idmercado inner join usuarios u on u.id_usuarios=a.usuarios_id_usuarios1  where m.idmercado="+idmercado.ToString("0.0", CultureInfo.InvariantCulture);

            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            List<MercadoApuesta> list = new List<MercadoApuesta>();
            MercadoApuesta m = null;

            while (res.Read())
            {
                //Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt16(5));
                m = new MercadoApuesta(res.GetString(0), res.GetDecimal(1), res.GetChar(2), res.GetFloat(3), res.GetFloat(4));
                list.Add(m);
            }

            con.Close();

            return list;

        }
        //Listado de registros DTO
        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;

                List<MercadoDTO> mercado = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
                    m = new MercadoDTO(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2),res.GetInt32(6));
                    mercado.Add(m);

                }

                con.Close();

                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        //Listado de registros DTO
        internal List<MercadoDTO> RetrieveDTOMP(int idpartido)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado where partido_idpartido1="+ idpartido.ToString();

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;

                List<MercadoDTO> mercado = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
                    m = new MercadoDTO(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2),res.GetInt32(6));
                    mercado.Add(m);

                }

                con.Close();

                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }
        //este metodo trae los valores de una cuota en especifico recibiendo como parametro el valor 
        internal Mercado GetCuota(int idMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            string sql = "select * from mercado where   ID =" + idMercado + "";
          //  sql = sql.Replace(",", ".");
            command.CommandText = sql;
            //command.CommandText = "select * from mercado where idmercado = 1.5 ";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;

               
                while (res.Read())
                {
                    // Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
                    m = new Mercado(res.GetDecimal(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetInt16(5),res.GetInt32(6));

                }

                con.Close();

                return m;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexión");
                return null;
            }

        }


        internal void UpdateOver(int IdMercado, float Cuota)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update mercado set CuotaO='"+Cuota.ToString("0.00", CultureInfo.InvariantCulture) +"' WHERE idmercado='"+IdMercado +"';";

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
        internal void UpdateUnder(int IdMercado, float Cuota)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update mercado set CuotaU='" + Cuota.ToString("0.00", CultureInfo.InvariantCulture) + "' WHERE idmercado='" + IdMercado + "';";

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