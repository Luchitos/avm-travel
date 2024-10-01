using AVMTravel.Core.Entities;
using System.Collections.Generic;

namespace AVMTravel.Core.Interfaces
{
    /// <summary>
    /// Interfaz para gestionar reservas y tours en un solo lugar.
    /// </summary>
    public interface IGestorReservasService
    {
        /// <summary>
        /// Agrega un nuevo tour.
        /// </summary>
        /// <param name="tour">El tour a agregar.</param>
        void AgregarTour(Tour tour);

        /// <summary>
        /// Muestra todos los tours disponibles.
        /// </summary>
        /// <returns>Una lista de todos los tours.</returns>
        IEnumerable<Tour> MostrarTours();

        /// <summary>
        /// Crea una reserva para un tour especificado.
        /// </summary>
        /// <param name="reserva">La reserva a crear.</param>
        void ReservarTour(Reserva reserva);

        /// <summary>
        /// Muestra todas las reservas realizadas.
        /// </summary>
        /// <returns>Una lista de todas las reservas.</returns>
        IEnumerable<Reserva> MostrarReservas();

        /// <summary>
        /// Elimina una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a eliminar.</param>
        void EliminarReserva(int id);

        /// <summary>
        /// Inicializa los tours de prueba.
        /// </summary>
        void InicializarTours();
    }
}
