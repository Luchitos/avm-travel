using System.Collections.Generic;


namespace AVMTravel.Core.Entities
{
    /// <summary>
    /// Clase que gestiona la creación de reservas y la lista de tours.
    /// </summary>
    public class GestorReservas
    {
        private List<Tour> _tours;
        private List<Reserva> _reservas;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GestorReservas"/>.
        /// </summary>
        public GestorReservas()
        {
            _tours = new List<Tour>();
            _reservas = new List<Reserva>();
        }

        /// <summary>
        /// Agrega un tour a la lista de tours.
        /// </summary>
        /// <param name="tour">El tour a agregar.</param> 
        public void AgregarTour(Tour tour)
        {
            _tours.Add(tour);
        }

        /// <summary>
        /// Muestra todos los tours disponibles.
        /// </summary>
        /// <returns>Una colección de tours.</returns>
        public IEnumerable<Tour> MostrarTours()
        {
            return _tours;
        }

        /// <summary>
        /// Reserva un tour y lo agrega a la lista de reservas.
        /// </summary>
        /// <param name="reserva">La reserva a agregar.</param>
        public void ReservarTour(Reserva reserva)
        {
            _reservas.Add(reserva);
        }

        /// <summary>
        /// Muestra todas las reservas realizadas.
        /// </summary>
        /// <returns>Una colección de reservas.</returns>
        public IEnumerable<Reserva> MostrarReservas()
        {
            return _reservas;
        }
    }
}
