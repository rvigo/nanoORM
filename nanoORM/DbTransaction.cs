using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using nanoORM.ConnectionUtils;

namespace nanoORM
{
    public class DbTransaction
    {
        public string CreateQuery<T>(T obj)
        {
            return Creator.CreateQueryString(obj);
        }

        public T SelectSingleItem<T>(T obj, string query)
        {
            (SqlConnection conn, SqlCommand cmd) = ConnectionUtil.ConnectionProvider();

            try
            {
                cmd.CommandText = query;
                cmd.Connection = conn;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                return Mapping.SingleItemMapping<T>(dr);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<T> SelectList<T>(string query)
        {
            (SqlConnection conn, SqlCommand cmd) = ConnectionUtil.ConnectionProvider();

            try
            {
                cmd.CommandText = query;
                cmd.Connection = conn;
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                return Mapping.ListMapping<T>(dr);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void ExecuteQuery(string query)
        {
            (SqlConnection conn, SqlCommand cmd) = ConnectionUtil.ConnectionProvider();

            try
            {
                cmd.CommandText = query;
                cmd.Connection = conn;
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
