using Parking.DataAccess.Base;
using Parking.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parking.DataAccess
{
    public class DALModelo
    {
        readonly DALSQLNative bd = new DALSQLNative();

        public List<Modelo> ListarModelos(int IDMarca)
        {
            List<Modelo> retval = new List<Modelo>();
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPListarModelos"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDMarca", IDMarca));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retval.Add(new Modelo
                                {
                                    IDModelo = reader["IDModelo"] == DBNull.Value ? 0 : int.Parse(reader["IDModelo"].ToString()),
                                    Descripcion = reader["Descripcion"] == DBNull.Value ? string.Empty : reader["Descripcion"].ToString()
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