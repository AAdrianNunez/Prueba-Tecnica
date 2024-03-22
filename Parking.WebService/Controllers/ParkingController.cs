using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parking.DataAccess;
using Parking.Entity;

namespace Parking.WebService.Controllers
{
    public class ParkingController : ApiController
    {
        #region Login
        [HttpPost]
        [Route("api/validarusuario")]
        public HttpResponseMessage ValidarUsuario(string Usuario, string Contrasena)
        {
            try
            {
                DALUsuario DALUsuario = new DALUsuario();
                return Request.CreateResponse(HttpStatusCode.OK, DALUsuario.ValidarUsuario(Usuario, Contrasena));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region Cliente
        [HttpPost]
        [Route("api/listarclientes")]
        public HttpResponseMessage ListarClientes()
        {
            try
            {
                DALCliente DALCliente = new DALCliente();
                return Request.CreateResponse(HttpStatusCode.OK, DALCliente.ListarClientes());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/registrarcliente")]
        public HttpResponseMessage RegistrarCliente(Cliente Cliente)
        {
            try
            {
                DALCliente DALCliente = new DALCliente();
                return Request.CreateResponse(HttpStatusCode.OK, DALCliente.RegistrarCliente(Cliente));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/modificarcliente")]
        public HttpResponseMessage ModificarCliente(Cliente Cliente)
        {
            try
            {
                DALCliente DALCliente = new DALCliente();
                return Request.CreateResponse(HttpStatusCode.OK, DALCliente.ModificarCliente(Cliente));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/eliminarcliente")]
        public HttpResponseMessage EliminarCliente(int IDCliente)
        {
            try
            {
                DALCliente DALCliente = new DALCliente();
                return Request.CreateResponse(HttpStatusCode.OK, DALCliente.EliminarCliente(IDCliente));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region Vehiculos        
        [HttpPost]
        [Route("api/listarvehiculos")]
        public HttpResponseMessage ListarVehiculos(int IDCliente)
        {
            try
            {
                DALVehiculo DALVehiculo = new DALVehiculo();
                return Request.CreateResponse(HttpStatusCode.OK, DALVehiculo.ListarVehiculos(IDCliente));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/listarmarcas")]
        public HttpResponseMessage ListarMarcas()
        {
            try
            {
                DALMarca DALMarca = new DALMarca();
                return Request.CreateResponse(HttpStatusCode.OK, DALMarca.ListarMarcas());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/listarmodelos")]
        public HttpResponseMessage ListarModelos(int IDMarca)
        {
            try
            {
                DALModelo DALModelo = new DALModelo();
                return Request.CreateResponse(HttpStatusCode.OK, DALModelo.ListarModelos(IDMarca));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/registrarvehiculo")]
        public HttpResponseMessage RegistrarVehiculo(Vehiculo Vehiculo)
        {
            try
            {
                DALVehiculo DALVehiculo = new DALVehiculo();
                return Request.CreateResponse(HttpStatusCode.OK, DALVehiculo.RegistrarVehiculo(Vehiculo));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/modificarvehiculo")]
        public HttpResponseMessage ModificarVehiculo(Vehiculo Vehiculo)
        {
            try
            {
                DALVehiculo DALVehiculo = new DALVehiculo();
                return Request.CreateResponse(HttpStatusCode.OK, DALVehiculo.ModificarVehiculo(Vehiculo));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/eliminarvehiculo")]
        public HttpResponseMessage EliminarVehiculo(int IDVehiculo)
        {
            try
            {
                DALVehiculo DALVehiculo = new DALVehiculo();
                return Request.CreateResponse(HttpStatusCode.OK, DALVehiculo.EliminarVehiculo(IDVehiculo));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        #endregion
    }
}