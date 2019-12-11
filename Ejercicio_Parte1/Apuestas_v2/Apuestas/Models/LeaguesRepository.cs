using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Apuestas.Models;

namespace Apuestas.Models
{
    // EJERCICIO 1
    public class LeaguesRepository
    {
        private MySqlConnection Connect()
        {
            string conexioString = "Server=34.211.20.148;Port=3306;Database=placemybet;Uid=examen;password=examen;SslMode=none";
            MySqlConnection con = new MySqlConnection(conexioString);
            return con;
        }

        internal List<League> GetLeagues()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from leagues";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<League> aListaLeague = new List<League>();
            League a = null; 


            while (res.Read())
            {
                
                a = new League(res.GetString(1), res.GetString(3));
                aListaLeague.Add(a);
            }

            con.Close();

            return aListaLeague;

        }

    }
}