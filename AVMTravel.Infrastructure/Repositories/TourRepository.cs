using System.Collections.Generic;
using System.Linq;
using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using AVMTravel.Infrastructure.Data;

namespace AVMTravel.Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly AvmTravelDbContext _context;

        public TourRepository()
        {
            _context = new AvmTravelDbContext();
        }

        /// <summary>
        /// Agrega un nuevo tour al sistema.
        /// </summary>
        /// <param name="tour">El tour a agregar.</param>
        public void AgregarTour(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtiene todos los tours disponibles.
        /// </summary>
        /// <returns>Una lista de todos los tours.</returns>
        public IEnumerable<Tour> ObtenerTodosLosTours()
        {
            return _context.Tours.ToList();
        }

        /// <summary>
        /// Obtiene un tour por su identificador.
        /// </summary>
        /// <param name="id">El identificador del tour.</param>
        /// <returns>El tour correspondiente al identificador proporcionado.</returns>
        public Tour ObtenerTourPorId(int id)
        {
            return _context.Tours.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Elimina un tour por su identificador.
        /// </summary>
        /// <param name="id">El identificador del tour a eliminar.</param>
        public void EliminarTour(int id)
        {
            var tour = _context.Tours.Find(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                _context.SaveChanges();
            }
        }
    }
}
