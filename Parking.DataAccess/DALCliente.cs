using Parking.DataAccess.Base;
using Parking.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parking.DataAccess
{
    public class DALCliente
    {
        readonly DALSQLNative bd = new DALSQLNative();

        public List<Cliente> ListarClientes()
        {
            List<Cliente> retval = new List<Cliente>();
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPListarClientes"))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retval.Add(new Cliente
                                {
                                    IDCliente = reader["IDCliente"] == DBNull.Value ? 0 : int.Parse(reader["IDCliente"].ToString()),
                                    Nombre = reader["Nombre"] == DBNull.Value ? string.Empty : reader["Nombre"].ToString(),
                                    Apellidos = reader["Apellidos"] == DBNull.Value ? string.Empty : reader["Apellidos"].ToString(),
                                    DNI = reader["DNI"] == DBNull.Value ? string.Empty : reader["DNI"].ToString(),
                                    Telefono = reader["Telefono"] == DBNull.Value ? string.Empty : reader["Telefono"].ToString(),
                                    Email = reader["Email"] == DBNull.Value ? string.Empty : reader["Email"].ToString()
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

        public int RegistrarCliente(Cliente Cliente)
        {
            int retval = 0;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPRegistrarCliente"))
                {
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Cliente.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellidos", Cliente.Apellidos));
                    cmd.Parameters.Add(new SqlParameter("@DNI", Cliente.DNI));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Cliente.Telefono));
                    cmd.Parameters.Add(new SqlParameter("@Email", Cliente.Email));
                    retval = bd.ExecuteCommandNonQuery();
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

        public int ModificarCliente(Cliente Cliente)
        {
            int retval = 0;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPModificarCliente"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDCliente", Cliente.IDCliente));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Cliente.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellidos", Cliente.Apellidos));
                    cmd.Parameters.Add(new SqlParameter("@DNI", Cliente.DNI));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Cliente.Telefono));
                    cmd.Parameters.Add(new SqlParameter("@Email", Cliente.Email));
                    retval = bd.ExecuteCommandNonQuery();
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

        public int EliminarCliente(int IDCliente)
        {
            int retval = 0;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPEliminarCliente"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
                    retval = bd.ExecuteCommandNonQuery();
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
