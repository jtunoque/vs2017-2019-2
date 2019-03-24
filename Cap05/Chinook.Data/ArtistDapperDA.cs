using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using Dapper;
using System.Linq;

namespace Chinook.Data
{
    public class ArtistDapperDA: BaseConnection
    {
        public int GetCount()
        {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            /* 1. Crear el objeto Connection*/
            using (IDbConnection cn = new SqlConnection(GetConection()))
            {

                result = cn.Query<int>(sql).Single();
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

                result = cn.Query<Artist>(sql).ToList();                
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

                result = cn.Query<Artist>(sql,
                    new { FiltroPorNombre = nombre }
                    ).ToList();
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

                result = cn.Query<Artist>(sql,
                   new { FiltroPorNombre = nombre },
                   commandType:CommandType.StoredProcedure
                   ).ToList();               
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

                result = cn.Query<int>(sql,
                    new
                    {
                        Nombre = entity.Name
                    },
                    commandType: CommandType.StoredProcedure).Single();
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
                    result = cn.Query<int>(sql,
                        new { Nombre = entity.Name },
                        commandType: CommandType.StoredProcedure,
                        transaction: transaction).Single();

                    transaction.Commit();
                }

                catch(Exception ex)
                {
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
                        result = cn.Query<int>(sql,
                           new {Nombre = entity.Name},
                           commandType: CommandType.StoredProcedure).Single();                     
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


        public Boolean UpdateArtistTXDist(Artist entity)
        {
            Boolean result = false;

            //Con el objeto TransactionScope 
            //se iniciar la transacción
            using (var tx = new TransactionScope())
            {
                try
                {

                    var dynamicParams = new DynamicParameters();
                    dynamicParams.Add("Nombre", entity.Name);
                    dynamicParams.Add("ID", entity.ArtistId);
                    dynamicParams.Add("RESULT", dbType:DbType.Boolean,
                            direction:ParameterDirection.Output);

                    var sql = "usp_UpdateArtist";
                    /* 1. Crear el objeto Connection*/
                    using (IDbConnection cn = new SqlConnection(GetConection()))
                    {
                        cn.Execute(sql,
                          dynamicParams,
                           commandType: CommandType.StoredProcedure);

                        result = dynamicParams.Get<Boolean>("RESULT");
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

        public Boolean DeleteArtistTXDist(int ID)
        {
            Boolean result = false;

            //Con el objeto TransactionScope 
            //se iniciar la transacción
            using (var tx = new TransactionScope())
            {
                try
                {

                    var sql = "usp_DeleteArtist";
                    /* 1. Crear el objeto Connection*/
                    using (IDbConnection cn = new SqlConnection(GetConection()))
                    {
                      result =  cn.Execute(sql,
                          new { ID = ID },
                           commandType: CommandType.StoredProcedure)>0;
                    }

                    //Con el método Complete se confirma la transacción
                    tx.Complete();

                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
