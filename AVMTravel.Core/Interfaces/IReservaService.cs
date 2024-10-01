using AVMTravel.Core.Entities;
using System.Collections.Generic;

namespace AVMTravel.Core.Interfaces
{
    /// <summary>
    /// Interfaz para gestionar las operaciones relacionadas con las reservas.
    /// </summary>
    public interface IReservaService
    {
        /// <summary>
        /// Crea una nueva reserva para un tour.
        /// </summary>
        /// <param name="reserva">La reserva a crear.</param>
        void ReservarTour(Reserva reserva);

        /// <summary>
        /// Obtiene todas las reservas.
        /// </summary>
        /// <returns>Una lista de todas las reservas.</returns>
        IEnumerable<Reserva> ObtenerTodasLasReservas();

        /// <summary>
        /// Obtiene una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva.</param>
        /// <returns>La reserva correspondiente al ID.</returns>
        Reserva ObtenerReservaPorId(int id);

        /// <summary>
        /// Elimina una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a eliminar.</param>
        void EliminarReserva(int id);
    }
}
