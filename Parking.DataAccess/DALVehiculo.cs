using Parking.DataAccess.Base;
using Parking.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parking.DataAccess
{
    public class DALVehiculo
    {
        readonly DALSQLNative bd = new DALSQLNative();

        public List<Vehiculo> ListarVehiculos(int IDCliente)
        {
            List<Vehiculo> retval = new List<Vehiculo>();
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPListarVehiculos"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDCliente", IDCliente));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                retval.Add(new Vehiculo
                                {
                                    IDVehiculo = reader["IDVehiculo"] == DBNull.Value ? 0 : int.Parse(reader["IDVehiculo"].ToString()),
                                    IDMarca = reader["IDMarca"] == DBNull.Value ? 0 : int.Parse(reader["IDMarca"].ToString()),
                                    NombreMarca = reader["NombreMarca"] == DBNull.Value ? string.Empty : reader["NombreMarca"].ToString(),
                                    IDModelo = reader["IDModelo"] == DBNull.Value ? 0 : int.Parse(reader["IDModelo"].ToString()),
                                    DescripcionModelo = reader["DescripcionModelo"] == DBNull.Value ? string.Empty : reader["DescripcionModelo"].ToString(),
                                    Placa = reader["Placa"] == DBNull.Value ? string.Empty : reader["Placa"].ToString()
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

        public int RegistrarVehiculo(Vehiculo Vehiculo)
        {
            int retval = 0;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPRegistrarVehiculo"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDCliente", Vehiculo.IDCliente));
                    cmd.Parameters.Add(new SqlParameter("@IDModelo", Vehiculo.IDModelo));
                    cmd.Parameters.Add(new SqlParameter("@Placa", Vehiculo.Placa));
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

        public int ModificarVehiculo(Vehiculo Vehiculo)
        {
            int retval = 0;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPModificarVehiculo"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDVehiculo", Vehiculo.IDVehiculo));
                    cmd.Parameters.Add(new SqlParameter("@IDModelo", Vehiculo.IDModelo));
                    cmd.Parameters.Add(new SqlParameter("@Placa", Vehiculo.Placa));
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

        public int EliminarVehiculo(int IDVehiculo)
        {
            int retval = 0;
            try
            {
                bd.Connect();
                using (SqlCommand cmd = bd.CreateCommand("USPEliminarVehiculo"))
                {
                    cmd.Parameters.Add(new SqlParameter("@IDVehiculo", IDVehiculo));
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