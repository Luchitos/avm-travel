using AVMTravel.Core.Entities;
using System.Collections.Generic;

namespace AVMTravel.Core.Interfaces
{
    public interface IReservaRepository
    {
        /// <summary>
        /// Crea una nueva reserva para un tour.
        /// </summary>
        /// <param name="reserva">La reserva a crear.</param>
        void ReservarTour(Reserva reserva);

        /// <summary>
        /// Obtiene todas las reservas realizadas.
        /// </summary>
        /// <returns>Una lista de todas las reservas.</returns>
        IEnumerable<Reserva> ObtenerTodasLasReservas();

        /// <summary>
        /// Obtiene una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a obtener.</param>
        /// <returns>La reserva correspondiente al identificador especificado.</returns>
        Reserva ObtenerReservaPorId(int id);

        /// <summary>
        /// Elimina una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a eliminar.</param>
        void EliminarReserva(int id);
    }
}
