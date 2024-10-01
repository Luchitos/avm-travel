using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using AVMTravel.Infrastructure.Data;

namespace AVMTravel.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AvmTravelDbContext _context;

        public ReservaRepository()
        {
            _context = new AvmTravelDbContext();
        }

        /// <summary>
        /// Agrega una nueva reserva para un tour.
        /// </summary>
        /// <param name="reserva">La reserva a crear.</param>
        public void ReservarTour(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtiene todas las reservas.
        /// </summary>
        /// <returns>Una lista de todas las reservas, incluyendo la información del tour asociado.</returns>
        public IEnumerable<Reserva> ObtenerTodasLasReservas()
        {
            return _context.Reservas.Include(r => r.Tour).ToList();
        }

        /// <summary>
        /// Obtiene una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva.</param>
        /// <returns>La reserva correspondiente al identificador proporcionado.</returns>
        public Reserva ObtenerReservaPorId(int id)
        {
            return _context.Reservas.Include(r => r.Tour).FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Elimina una reserva por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la reserva a eliminar.</param>
        public void EliminarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
        }
    }
}
