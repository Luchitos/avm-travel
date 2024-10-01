using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;


namespace AVMTravel.Services.Services
{
    /// <summary>
    /// Servicio para gestionar reservas y tours en un solo lugar.
    /// </summary>
    public class GestorReservasService : IGestorReservasService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IReservaRepository _reservaRepository;

        public GestorReservasService(ITourRepository tourRepository, IReservaRepository reservaRepository)
        {
            _tourRepository = tourRepository;
            _reservaRepository = reservaRepository;
        }

        /// <summary>
        /// Agrega un nuevo tour.
        /// </summary>
        /// <param name="tour">El tour a agregar.</param>
        public void AgregarTour(Tour tour)
        {
            if (tour == null)
            {
                throw new ArgumentNullException(nameof(tour), "El tour no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(tour.Nombre))
            {
                throw new ArgumentException("El nombre del tour no puede estar vacío.");
            }

            if (tour.Precio <= 0)
            {
                throw new ArgumentException("El precio del tour debe ser mayor que cero.");
            }

            // Validar que el tour no exista ya en la base de datos
            var tourExistente = _tourRepository.ObtenerTodosLosTours()
                                .FirstOrDefault(t => t.Nombre == tour.Nombre && t.Destino == tour.Destino);

            if (tourExistente != null)
            {
                throw new InvalidOperationException("El tour ya existe con el mismo nombre y destino.");
            }

            _tourRepository.AgregarTour(tour);
        }


        /// <summary>
        /// Muestra todos los tours disponibles.
        /// </summary>
        /// <returns>Una lista de todos los tours.</returns>
        public IEnumerable<Tour> MostrarTours()
        {
            return _tourRepository.ObtenerTodosLosTours()
                .Where(t => t.FechaInicio >= DateTime.Now);  // Solo tours futuros
        }


        /// <summary>
        /// Crea una reserva para un tour especificado.
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

            // Verificar que el Tour existe
            var tour = _tourRepository.ObtenerTourPorId(reserva.TourId);
            if (tour == null)
            {
                throw new InvalidOperationException("El tour especificado no existe.");
            }

            // Lógica adicional: verificar que la fecha de reserva no esté en el pasado
            if (tour.FechaInicio < reserva.FechaReserva)
            {
                throw new InvalidOperationException("La fecha de reserva no puede estar en el pasado.");
            }

            _reservaRepository.ReservarTour(reserva);
        }


        /// <summary>
        /// Muestra todas las reservas realizadas.
        /// </summary>
        /// <returns>Una lista de todas las reservas.</returns>
        public IEnumerable<Reserva> MostrarReservas()
        {
            return _reservaRepository.ObtenerTodasLasReservas()
                .Where(r => r.FechaReserva >= DateTime.Now.AddMonths(-12));  // Reservas del último año
        }


        /// <summary>
        /// Elimina una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a eliminar.</param>
        public void EliminarReserva(int id)
        {
            var reserva = _reservaRepository.ObtenerReservaPorId(id);
            if (reserva == null)
                throw new InvalidOperationException("La reserva especificada no existe.");

            var tour = _tourRepository.ObtenerTourPorId(reserva.TourId);
            if (tour != null && tour.FechaInicio <= DateTime.Now)
                throw new InvalidOperationException("No se puede eliminar una reserva para un tour que ya ha comenzado.");

            _reservaRepository.EliminarReserva(id);
        }

        /// <summary>
        /// Inicializa algunos tours y reservas por defecto si no existen en la base de datos.
        /// </summary>
        public void InicializarTours()
        {
            // Verificar si ya hay tours en la base de datos
            if (!_tourRepository.ObtenerTodosLosTours().Any())
            {
                var tour1 = new Tour { Nombre = "Tour al Caribe", Destino = "Caribe", FechaInicio = DateTime.Now.AddDays(30), FechaFin = DateTime.Now.AddDays(37), Precio = 1000};
                var tour2 = new Tour { Nombre = "Tour por Europa", Destino = "Europa", FechaInicio = DateTime.Now.AddDays(60), FechaFin = DateTime.Now.AddDays(75), Precio = 2000};
                var tour3 = new Tour { Nombre = "Tour a la Patagonia", Destino = "Patagonia", FechaInicio = DateTime.Now.AddDays(45), FechaFin = DateTime.Now.AddDays(50), Precio = 1500};

                AgregarTour(tour1);
                AgregarTour(tour2);
                AgregarTour(tour3);
            }

            // Verificar si ya hay reservas en la base de datos
            if (!_reservaRepository.ObtenerTodasLasReservas().Any())
            {
                var reserva1 = new Reserva { Cliente = "Juan Pérez", FechaReserva = DateTime.Now, TourId = 1 };
                var reserva2 = new Reserva { Cliente = "Ana Gómez", FechaReserva = DateTime.Now, TourId = 2 };

                ReservarTour(reserva1);
                ReservarTour(reserva2);
            }
        }

    }
}
