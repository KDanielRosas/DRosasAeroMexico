using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace SL.Controllers
{
    public class ApiRestController : ApiController
    {
        [HttpPost]
        [Route("api/Usuario/Login")]
        public IHttpActionResult Login([FromBody] ML.Usuario usuario)
        {
            if (usuario.UserName == string.Empty || usuario.Password == string.Empty)
            {
                return BadRequest();
            }
            else
            {
                bool autorice = BL.Login.CheckUser(usuario.UserName, usuario.Password);
                if (autorice)
                {
                    string r = "Autorice";
                    return Ok(r);
                }
                else
                {
                    string r = "No autorice";
                    return Ok(r);
                }
            }
        }//Login

        [HttpGet]
        [Route("api/Vuelo/GetVuelo")]
        public IHttpActionResult GetVuelo([FromBody] ML.RequestVuelo requestVuelo)
        {
            if (requestVuelo.FechaInicio == null || requestVuelo.FechaFin == null)
            {
                return BadRequest();
            }
            else
            {
                var vuelo = BL.Vuelo.GetVuelo(requestVuelo.FechaInicio, requestVuelo.FechaFin);
                if (vuelo.Count == 0)
                {
                    string r = "No hay vuelos registrados en ese rango de fechas";
                    return Ok(r);
                }
                else
                {
                    return Ok(vuelo);
                }
                
            }
        }//GetVuelo

        [HttpPost]
        [Route("api/Vuelo/AddVuelo")]
        public IHttpActionResult AddVuelo([FromBody] ML.RequestVueloReservado request)
        {               
            bool response = false;
            if (request.IdVuelos.Count != request.IdUsuarios.Count)
            {
                return BadRequest();
            }
            for (int i = 0; i < request.IdVuelos.Count; i++)
            {
                bool result = BL.Vuelo.AddVueloReservado(request.IdUsuarios.ElementAt(i), request.IdVuelos[i]);
                if (result)
                {
                    response = true;
                }
                else
                {
                    response = false;
                }
            }
            if (response)
            {
                return Ok("Exitoso");
            }
            else
            {
                return InternalServerError();
            }
        }//AddVuelo

        [HttpPost]
        [Route("api/Pasajero/Add")]
        public IHttpActionResult AddPasajero([FromBody] ML.Pasajero pasajero)
        {
            if (pasajero.Nombre == "" || pasajero.ApellidoPaterno == "" || pasajero.ApellidoMaterno == "")
            {
                return BadRequest();
            }
            else
            {
                bool response = BL.Pasajero.Add(pasajero);

                if (response)
                {
                    return Ok("Registro exitoso");
                }
                else
                {
                    return Ok("Error");
                }
            }            
        }//PasajeroAdd
    }
}