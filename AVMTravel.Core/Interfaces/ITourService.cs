using AVMTravel.Core.Entities;
using System.Collections.Generic;

namespace AVMTravel.Core.Interfaces
{
    /// <summary>
    /// Interfaz para gestionar las operaciones relacionadas con los tours.
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Agrega un nuevo tour.
        /// </summary>
        /// <param name="tour">El tour a agregar.</param>
        void AgregarTour(Tour tour);

        /// <summary>
        /// Obtiene todos los tours.
        /// </summary>
        /// <returns>Una lista de todos los tours.</returns>
        IEnumerable<Tour> ObtenerTodosLosTours();

        /// <summary>
        /// Obtiene un tour por su identificador.
        /// </summary>
        /// <param name="id">El identificador del tour.</param>
        /// <returns>El tour correspondiente al ID.</returns>
        Tour ObtenerTourPorId(int id);

        /// <summary>
        /// Elimina un tour por su identificador.
        /// </summary>
        /// <param name="id">El identificador del tour a eliminar.</param>
        void EliminarTour(int id);
    }
}
