using System.Web.Mvc;
using AVMTravel.Web.ViewModels;
using System;
using AVMTravel.Core.Interfaces;
using System.Linq;
using AVMTravel.Core.Entities;

namespace AVMTravel.Web.Controllers
{
    [Authorize]
    public class TourController : Controller
    {
        private readonly IGestorReservasService _gestorReservasService;

        /// <summary>
        /// Constructor para inicializar el servicio de gestor de reservas.
        /// </summary>
        /// <param name="gestorReservasService">Servicio de gestor de reservas inyectado.</param>
        public TourController(IGestorReservasService gestorReservasService)
        {
            _gestorReservasService = gestorReservasService;
        }

        /// <summary>
        /// Acción para mostrar la lista de tours disponibles.
        /// </summary>
        /// <returns>Vista con los tours disponibles.</returns>
        public ActionResult Index()
        {
            var tours = _gestorReservasService.MostrarTours().Select(t => new TourViewModel
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Destino = t.Destino,
                FechaInicio = t.FechaInicio,
                FechaFin = t.FechaFin,
                Precio = t.Precio
            });

            return View(tours);
        }

        /// <summary>
        /// Acción para mostrar la lista de todos los tours.
        /// </summary>
        /// <returns>Vista con los tours obtenidos del servicio.</returns>
        public ActionResult MostrarTours()
        {
            var tours = _gestorReservasService.MostrarTours();
            return View(tours);
        }

        /// <summary>
        /// Acción para reservar un tour.
        /// </summary>
        /// <param name="tourId">ID del tour a reservar.</param>
        /// <param name="cliente">Nombre del cliente que realiza la reserva.</param>
        /// <returns>Redirige a la vista de tours.</returns>
        public ActionResult ReservarTour(int tourId, string cliente)
        {
            var reserva = new Reserva
            {
                Cliente = cliente,
                FechaReserva = DateTime.Now,
                TourId = tourId
            };

            _gestorReservasService.ReservarTour(reserva);
            TempData["SuccessMessage"] = "¡Tu reserva se ha realizado con éxito!";
            return RedirectToAction("MostrarTours");
        }
    }
}
