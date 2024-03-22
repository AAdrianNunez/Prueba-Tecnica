using Newtonsoft.Json;
using Parking.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;

namespace Parking.Web.Controllers
{
    public class HomeController : Controller
    {
        public string URLService = "http://localhost:51417/api/";

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ValidarUsuario(string Usuario, string Contrasena)
        {
            try
            {
                string URL = Path.Combine(URLService, "validarusuario", "?Usuario=" + Usuario + "&Contrasena=" + Contrasena);
                string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
                bool result = JsonConvert.DeserializeObject<bool>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }        

        public ActionResult Index()
        {
            return View();
        }

        #region Cliente        
        public ActionResult GestionClientes()
        {
            return View();
        }

        public ActionResult ListarClientes()
        {
            try
            {                
                string URL = Path.Combine(URLService, "listarclientes");
                string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
                List<Cliente> ListCliente = JsonConvert.DeserializeObject<List<Cliente>>(retval);
                return Json(ListCliente, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult NuevoCliente()
        {
            return PartialView();
        }

        public ActionResult ModificarCliente(int IDCliente, string Nombre, string Apellidos, string DNI, string Telefono, string Email)
        {
            try
            {   
                object Cliente = new { 
                     IDCliente
		            ,Nombre
		            ,Apellidos
		            ,DNI
		            ,Telefono
		            ,Email
                };
                var Object = JsonConvert.SerializeObject(Cliente);
                string URL = Path.Combine(URLService, "modificarcliente");
                string retval = ServiceRecovery(Object, URL, "POST", out HttpStatusCode HttpStatusCode);
                int result = JsonConvert.DeserializeObject<int>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RegistrarCliente(string Nombre, string Apellidos, string DNI, string Telefono, string Email)
        {
            try
            {
                object Cliente = new {                      
		             Nombre
		            ,Apellidos
		            ,DNI
		            ,Telefono
		            ,Email
                };
                var Object = JsonConvert.SerializeObject(Cliente);
                string URL = Path.Combine(URLService, "registrarcliente");
                string retval = ServiceRecovery(Object, URL, "POST", out HttpStatusCode HttpStatusCode);
                int result = JsonConvert.DeserializeObject<int>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EliminarCliente(int IDCliente)
        {
            try
            {
                string URL = Path.Combine(URLService, "eliminarcliente", "?IDCliente=" + IDCliente);
                string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
                int result = JsonConvert.DeserializeObject<int>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Vehiculo
        public ActionResult GestionVehiculos(int IDCliente)
        {
            ViewData["IDCliente"] = IDCliente;
            return View();
        }

        public ActionResult ListarVehiculos(int IDCliente)
        {
            try
            {
                string URL = Path.Combine(URLService, "listarvehiculos", "?IDCliente=" + IDCliente);
                string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
                List<Vehiculo> ListVehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(retval);
                return Json(ListVehiculos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult NuevoVehiculo()
        {
            ViewData["ListMarca"] = SelectMarca();
            return PartialView();
        }

        public SelectList SelectMarca()
        {
            string URL = Path.Combine(URLService, "listarmarcas");
            string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
            List<Marca> ListMarca = JsonConvert.DeserializeObject<List<Marca>>(retval);
            List<Marca> ListResult = new List<Marca>
            {
                new Marca() { IDMarca = 0, Nombre = "Selecionar" }
            };
            ListResult.AddRange(ListMarca);
            var ListSelect = new SelectList(ListResult, "IDMarca", "Nombre");
            return ListSelect;
        }


        public ActionResult ListarModelos(int IDMarca)
        {
            try
            {
                string URL = Path.Combine(URLService, "listarmodelos", "?IDMarca=" + IDMarca);
                string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
                List<Modelo> ListModelos = JsonConvert.DeserializeObject<List<Modelo>>(retval);
                return Json(ListModelos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ModificarVehiculo(int IDVehiculo, int IDModelo, string Placa)
        {
            try
            {
                object Vehiculo = new
                {
                     IDVehiculo
                    ,IDModelo
                    ,Placa
                };
                var Object = JsonConvert.SerializeObject(Vehiculo);
                string URL = Path.Combine(URLService, "modificarVehiculo");
                string retval = ServiceRecovery(Object, URL, "POST", out HttpStatusCode HttpStatusCode);
                int result = JsonConvert.DeserializeObject<int>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RegistrarVehiculo(string IDCliente, string IDModelo, string Placa)
        {
            try
            {
                object Vehiculo = new
                {
                     IDCliente
                    ,IDModelo
                    ,Placa
                };
                var Object = JsonConvert.SerializeObject(Vehiculo);
                string URL = Path.Combine(URLService, "registrarVehiculo");
                string retval = ServiceRecovery(Object, URL, "POST", out HttpStatusCode HttpStatusCode);
                int result = JsonConvert.DeserializeObject<int>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EliminarVehiculo(int IDVehiculo)
        {
            try
            {
                string URL = Path.Combine(URLService, "eliminarVehiculo", "?IDVehiculo=" + IDVehiculo);
                string retval = ServiceRecovery(string.Empty, URL, "POST", out HttpStatusCode HttpStatusCode);
                int result = JsonConvert.DeserializeObject<int>(retval);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion




        private string ServiceRecovery(string Object, string URL, string Method, out HttpStatusCode HttpStatusCode)
        {
            string retval = string.Empty;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                byte[] data = Encoding.UTF8.GetBytes(Object);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = Method;
                request.ContentType = "application/json";
                request.Timeout = Timeout.Infinite;
                request.KeepAlive = true;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                WebResponse response = request.GetResponse();
                HttpStatusCode = ((HttpWebResponse)response).StatusCode;
                retval = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException ex)
            {
                WebResponse response = ex.Response;
                HttpStatusCode = ((HttpWebResponse)response).StatusCode;
                retval = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            return retval;
        }
    }
}