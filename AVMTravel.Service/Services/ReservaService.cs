using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AVMTravel.Services.Services
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con las reservas.
    /// </summary>
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        /// <summary>
        /// Crea una nueva reserva para un tour.
        /// </summary>
        /// <param name="reserva">La reserva a crear.</param>
        public void ReservarTour(Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");
            }

            if (string.IsNullOrWhiteSpace(reserva.Cliente))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacío.");
            }

            if (reserva.TourId <= 0)
            {
                throw new ArgumentException("El ID del tour debe ser mayor que cero.");
            }

            _reservaRepository.ReservarTour(reserva);
        }

        /// <summary>
        /// Obtiene todas las reservas.
        /// </summary>
        /// <returns>Una lista de todas las reservas.</returns>
        public IEnumerable<Reserva> ObtenerTodasLasReservas()
        {
            return _reservaRepository.ObtenerTodasLasReservas();
        }

        /// <summary>
        /// Obtiene una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva.</param>
        /// <returns>La reserva correspondiente al ID.</returns>
        public Reserva ObtenerReservaPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la reserva debe ser mayor que cero.");
            }

            var reserva = _reservaRepository.ObtenerReservaPorId(id);

            if (reserva == null)
            {
                throw new KeyNotFoundException("La reserva no existe.");
            }

            return reserva;
        }

        /// <summary>
        /// Elimina una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a eliminar.</param>
        public void EliminarReserva(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la reserva debe ser mayor que cero.");
            }

            _reservaRepository.EliminarReserva(id);
        }
    }
}
