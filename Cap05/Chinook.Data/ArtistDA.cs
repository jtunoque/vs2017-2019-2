using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Chinook.Data
{
    public class ArtistDA: BaseConnection
    {
        public int GetCount()
        {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {
                cn.Open();
                /*2. Creando una instancia del objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                /*Ejecutando el commando*/
                result = (int)cmd.ExecuteScalar();
            }

            
            return result;
        }

        public IEnumerable<Artist> Gets()
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {
                cn.Open();
                /*2. Creando una instancia del objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                /*Ejecutando el commando*/
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while(reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }
            }

            return result;
        }

        public IEnumerable<Artist> GetsWithParam(string nombre)
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist WHERE Name LIKE @FiltroPorNombre ";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {
                cn.Open();
                /*2. Creando una instancia del objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                //Configurando los parámetros de la consulta SQL                
                cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre", nombre));


                /*Ejecutando el commando*/
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }
            }

            return result;
        }

        public IEnumerable<Artist> GetsWithParamSP(string nombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtists";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {
                cn.Open();
                /*2. Creando una instancia del objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                //Configurando los parámetros de la consulta SQL                
                cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre", nombre));


                /*Ejecutando el commando*/
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }
            }

            return result;
        }

        public int InsertArtist(Artist entity)
        {
            var result = 0;
            var sql = "usp_InsertArtist";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {
                cn.Open();
                /*2. Creando una instancia del objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                //Configurando los parámetros de la consulta SQL                
                cmd.Parameters.Add(new SqlParameter("@Nombre", entity.Name));

                /*Ejecutando el commando*/
                result = Convert.ToInt32(cmd.ExecuteScalar());
               
            }

            return result;
        }

        public int InsertArtistTX(Artist entity)
        {
            var result = 0;
            var sql = "usp_InsertArtist";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {
                cn.Open();
                //Iniciando la transacción local
                var transaction = cn.BeginTransaction();

                try
                {
                    /*2. Creando una instancia del objeto command*/
                    IDbCommand cmd = new SqlCommand(sql);
                    cmd.Transaction = transaction; //Asignando la transaccioón
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    //Configurando los parámetros de la consulta SQL                
                    cmd.Parameters.Add(new SqlParameter("@Nombre", entity.Name));

                    /*Ejecutando el commando*/
                    result = Convert.ToInt32(cmd.ExecuteScalar());


                   // throw new Exception("Error de transacción");
                     
                    //Con el método commit se confirma la transacción
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    //Con el método Rollback se deshace la transacción
                    transaction.Rollback();
                }               

            }

            return result;
        }

        public int InsertArtistTXDist(Artist entity)
        {
            var result = 0;

            //Con el objeto TransactionScope 
            //se iniciar la transacción
            using (var tx = new TransactionScope())
            {
                try
                {
                    var sql = "usp_InsertArtist";
                    /* 1. Crear el objeto Connection*/
                    using (IDbConnection cn = new SqlConnection(GetConection()))
                    {
                        cn.Open();
                        /*2. Creando una instancia del objeto command*/
                        IDbCommand cmd = new SqlCommand(sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = cn;
                        //Configurando los parámetros de la consulta SQL                
                        cmd.Parameters.Add(new SqlParameter("@Nombre", entity.Name));

                        /*Ejecutando el commando*/
                        result = Convert.ToInt32(cmd.ExecuteScalar());

                    }                    

                    //Con el método Complete se confirma la transacción
                    tx.Complete();

                }
                catch (Exception)
                {

                }
            }
            return result;
        }
    }
}
