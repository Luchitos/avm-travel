using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AVMTravel.Services.Services
{

    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con los tours.
    /// </summary>
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        
        /// <summary>
        /// Obtiene todos los tours.
        /// </summary>
        /// <returns>Una lista de todos los tours.</returns>
        public IEnumerable<Tour> ObtenerTodosLosTours()
        {
            return _tourRepository.ObtenerTodosLosTours();
        }

        public void AgregarTour(Tour tour)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour), "El tour no puede ser nulo.");

            // Validaciones adicionales
            if (string.IsNullOrWhiteSpace(tour.Nombre))
                throw new ArgumentException("El nombre del tour es requerido.", nameof(tour.Nombre));

            // Validar que el tour no exista ya
            if (_tourRepository.ObtenerTodosLosTours().Any(t => t.Nombre == tour.Nombre && t.Destino == tour.Destino))
                throw new InvalidOperationException("El tour ya existe.");
            
            if (string.IsNullOrWhiteSpace(tour.Destino))
            {
                throw new ArgumentException("El destino del tour no puede estar vacío.");
            }

            if (tour.FechaInicio >= tour.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de fin.");
            }

            if (tour.Precio <= 0)
            {
                throw new ArgumentException("El precio del tour debe ser mayor a cero.");
            }

            _tourRepository.AgregarTour(tour);
        }

        /// <summary>
        /// Obtiene un tour por su identificador.
        /// </summary>
        /// <param name="id">El identificador del tour.</param>
        /// <returns>El tour correspondiente al ID.</returns>
        public Tour ObtenerTourPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del tour debe ser mayor que cero.");
            }

            return _tourRepository.ObtenerTourPorId(id);
        }

        public void EliminarTour(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del tour debe ser mayor que cero.", nameof(id));

            // Verificar que el tour existe
            var tour = _tourRepository.ObtenerTourPorId(id);
            if (tour == null)
                throw new InvalidOperationException("El tour especificado no existe.");

            _tourRepository.EliminarTour(id);
        }
    }

}