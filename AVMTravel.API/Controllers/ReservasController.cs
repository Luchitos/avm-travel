using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AVMTravel.Core.Interfaces;
using AVMTravel.API.Models;
using AVMTravel.Core.Entities;

namespace AVMTravel.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar las reservas de tours.
    /// </summary>
    [RoutePrefix("api/reservas")]
    public class ReservasController : ApiController
    {
        private readonly IReservaService _reservaService;

        /// <summary>
        /// Constructor del controlador que recibe el servicio de reservas.
        /// </summary>
        /// <param name="reservaService">Servicio para gestionar reservas.</param>
        public ReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        /// <summary>
        /// Reserva un tour.
        /// </summary>
        /// <param name="reservaDto">Objeto DTO que contiene los datos de la reserva.</param>
        /// <returns>Resultado de la acción HTTP.</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult ReservarTour([FromBody] ReservaDto reservaDto)
        {
            if (reservaDto == null)
                return BadRequest("Datos de reserva inválidos.");

            var reserva = new Reserva
            {
                Cliente = reservaDto.Cliente,
                FechaReserva = reservaDto.FechaReserva,
                TourId = reservaDto.TourId
            };

            _reservaService.ReservarTour(reserva);
            return Created("", reserva);
        }

        /// <summary>
        /// Obtiene todas las reservas.
        /// </summary>
        /// <returns>Lista de reservas en formato JSON.</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult ObtenerReservas()
        {
            var reservas = _reservaService.ObtenerTodasLasReservas();
            return Ok(reservas);
        }

        /// <summary>
        /// Elimina una reserva por su ID.
        /// </summary>
        /// <param name="id">ID de la reserva a eliminar.</param>
        /// <returns>Resultado de la acción HTTP.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult EliminarReserva(int id)
        {
            _reservaService.EliminarReserva(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
