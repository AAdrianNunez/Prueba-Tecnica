using Parking.DataAccess.Base;
using Parking.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parking.DataAccess
{
    public class DALMarca
    {
        readonly DALSQLNative bd = new DALSQLNative();

        public List<Marca> ListarMarcas()
        {
            List<Marca> retval = new List<Marca>();
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPListarMarcas"))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retval.Add(new Marca
                                {
                                    IDMarca = reader["IDMarca"] == DBNull.Value ? 0 : int.Parse(reader["IDMarca"].ToString()),
                                    Nombre = reader["Nombre"] == DBNull.Value ? string.Empty : reader["Nombre"].ToString()
                                });
                            }
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bd.Disconnect();
            }
            return retval;
        }
    }
}