using Parking.DataAccess.Base;
using Parking.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parking.DataAccess
{
    public class DALUsuario
    {
        readonly DALSQLNative bd = new DALSQLNative();

        public bool ValidarUsuario(string Usuario, string Contrasena)
        {
            bool retval = false;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPValidarUsuario"))
                {
                    cmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Contrasena", Contrasena));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retval = (reader["IDUsuario"] == DBNull.Value ? 0 : int.Parse(reader["IDUsuario"].ToString())) > 0;
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
