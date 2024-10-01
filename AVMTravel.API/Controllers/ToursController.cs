using System.Collections.Generic;
using System.Web.Http;
using AVMTravel.Core.Interfaces;
using AVMTravel.API.Models;
using AVMTravel.Core.Entities;
using System.Net;
using System.Linq;

namespace AVMTravel.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar los tours.
    /// </summary>
    [RoutePrefix("api/tours")]
    public class ToursController : ApiController
    {
        private readonly ITourService _tourService;

        /// <summary>
        /// Constructor del controlador que recibe el servicio de tours.
        /// </summary>
        /// <param name="tourService">Servicio para gestionar tours.</param>
        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        /// <summary>
        /// Agrega un nuevo tour.
        /// </summary>
        /// <param name="tourDto">Objeto DTO que contiene los datos del tour.</param>
        /// <returns>Resultado de la acción HTTP.</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult AgregarTour([FromBody] TourDto tourDto)
        {
            if (tourDto == null)
                return BadRequest("Datos de tour inválidos.");

            var tour = new Tour
            {
                Nombre = tourDto.Nombre,
                Destino = tourDto.Destino,
                FechaInicio = tourDto.FechaInicio,
                FechaFin = tourDto.FechaFin,
                Precio = tourDto.Precio
            };

            _tourService.AgregarTour(tour);
            return Created("", tour);
        }

        /// <summary>
        /// Obtiene todos los tours.
        /// </summary>
        /// <returns>Lista de tours en formato JSON.</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult ObtenerTours()
        {
            var tours = _tourService.ObtenerTodosLosTours();
            var tourDtos = tours.Select(t => new TourDto
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Destino = t.Destino,
                FechaInicio = t.FechaInicio,
                FechaFin = t.FechaFin,
                Precio = t.Precio
            }).ToList();

            return Ok(tourDtos);
        }

        /// <summary>
        /// Elimina un tour por su ID.
        /// </summary>
        /// <param name="id">ID del tour a eliminar.</param>
        /// <returns>Resultado de la acción HTTP.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult EliminarTour(int id)
        {
            _tourService.EliminarTour(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
