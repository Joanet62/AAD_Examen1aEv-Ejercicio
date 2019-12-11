using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace Apuestas.Models
{
    public class MercadosRepository
    {
        //private MySqlConnection Connect()
        //{
        //    string conexioString = "Server=127.0.0.1;Port=3306;Database=apuesta4;Uid=root;password=Joan123456;SslMode=none";           
        //    MySqlConnection con = new MySqlConnection(conexioString);
        //    return con;
        //}

        internal Mercado Retrieve()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from mercado";

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();

            //Mercado m = null;

            //while (res.Read())
            //{
            //    Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt16(5));
            //    m = new Mercado(res.GetDecimal(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetInt16(5));
            //}

            //con.Close();

            //return m;
            


            return null;
        }
        //
        internal List<MercadoApuesta> GetMercadoApuesta(decimal idmercado)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select u.email,m.idmercado,a.tipo_O_U,a.cuota,a.dinero from mercado m inner join apuestas a on a.mercado_idmercado1=m.idmercado inner join usuarios u on u.id_usuarios=a.usuarios_id_usuarios1  where m.idmercado="+idmercado.ToString("0.0", CultureInfo.InvariantCulture);

            //con.Open();
            //MySqlDataReader res = command.ExecuteReader();
            //List<MercadoApuesta> list = new List<MercadoApuesta>();
            //MercadoApuesta m = null;

            //while (res.Read())
            //{
            //    //Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt16(5));
            //    m = new MercadoApuesta(res.GetString(0), res.GetDecimal(1), res.GetChar(2), res.GetFloat(3), res.GetFloat(4));
            //    list.Add(m);
            //}

            //con.Close();

            //return list;
        
            return null;
        }
        
        internal List<Mercado> GetMercados()
        {
        //    //MySqlConnection con = Connect();
        //    //MySqlCommand command = con.CreateCommand();
        //    //command.CommandText = "select * from mercado";

        //    //try
        //    //{
        //    //    con.Open();
        //    //    MySqlDataReader res = command.ExecuteReader();

        //    //    MercadoDTO m = null;

        //    //    List<MercadoDTO> mercado = new List<MercadoDTO>();
        //    //    while (res.Read())
        //    //    {
        //    //        Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
        //    //        m = new MercadoDTO(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2));
        //    //        mercado.Add(m);

        //    //    }

        //    //    con.Close();

        //    //    return mercado;
        //    //}
        //    //catch (MySqlException e)
        //    //{
        //    //    Debug.WriteLine("Error de conexión");
        //    //    return null;
        //    //}
        //EA5-12_2       
        List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                // mercados = context.Mercado.Include(p => p.Partido).ToList();
                mercados = context.Mercado.ToList();
             }

            return mercados;
        }
        //EA6-3
        internal List<Mercado> GetMercadosInclude()
        {
            //    //MySqlConnection con = Connect();
            //    //MySqlCommand command = con.CreateCommand();
            //    //command.CommandText = "select * from mercado";

            //    //try
            //    //{
            //    //    con.Open();
            //    //    MySqlDataReader res = command.ExecuteReader();

            //    //    MercadoDTO m = null;

            //    //    List<MercadoDTO> mercado = new List<MercadoDTO>();
            //    //    while (res.Read())
            //    //    {
            //    //        Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
            //    //        m = new MercadoDTO(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2));
            //    //        mercado.Add(m);

            //    //    }

            //    //    con.Close();

            //    //    return mercado;
            //    //}
            //    //catch (MySqlException e)
            //    //{
            //    //    Debug.WriteLine("Error de conexión");
            //    //    return null;
            //    //}    
            //EA6-3
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                // mercados = context.Mercado.Include(p => p.Partido).ToList();
                mercados = context.Mercado.Include(p => p.Partido).ToList();
            }

            return mercados;
        }
        //EA6-7
        internal MercadoDTO ToDTO(Mercado e)
        {

            return new MercadoDTO(e.IdMercado, e.CuotaOver,e.CuotaUnder);
        }
        //EA6-7
        internal List<MercadoDTO> RetrieveDTO()
        {

            List<MercadoDTO> mercadoDTOs = new List<MercadoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercadoDTOs = context.Mercado.Select(d => ToDTO(d)).ToList();
            }

            return mercadoDTOs;
        }
        //EA5-12_4
        internal Mercado Retrieve(float idmercado)
        {
           
            Mercado mercados = new Mercado();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercado.Where(d=>d.IdMercado==idmercado).First();
            }

            return mercados;
        }
        //este metodo trae los valores de una cuota en especifico recibiendo como parametro el valor 
        internal Mercado GetCuota(decimal idMercado)
        {
            //  MySqlConnection con = Connect();
            //  MySqlCommand command = con.CreateCommand();
            //  string sql = "select * from mercado where idmercado =" + idMercado.ToString("0.0", CultureInfo.InvariantCulture) + "";
            ////  sql = sql.Replace(",", ".");
            //  command.CommandText = sql;
            //  //command.CommandText = "select * from mercado where idmercado = 1.5 ";

            //  try
            //  {
            //      con.Open();
            //      MySqlDataReader res = command.ExecuteReader();

            //      Mercado m = null;


            //      while (res.Read())
            //      {
            //          // Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
            //          m = new Mercado(res.GetDecimal(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetInt16(5));

            //      }

            //      con.Close();

            //      return m;
            //  }
            //  catch (MySqlException e)
            //  {
            //      Debug.WriteLine("Error de conexión");
            //    return null;
            //}
            return null;
        }


        internal void UpdateOver(float IdMercado, float Cuota)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "update mercado set CuotaO='"+Cuota.ToString("0.00", CultureInfo.InvariantCulture) +"' WHERE idmercado='"+IdMercado.ToString("0.0", CultureInfo.InvariantCulture) +"';";

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
        internal void UpdateUnder(float IdMercado, float Cuota)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "update mercado set CuotaU='" + Cuota.ToString("0.00", CultureInfo.InvariantCulture) + "' WHERE idmercado='" + IdMercado.ToString("0.00", CultureInfo.InvariantCulture) + "';";

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
        //AE6-1
        internal void Save(Mercado d)
        {
            

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Mercado.Add(d);
                context.SaveChanges();
            }

        }
       
    }
}