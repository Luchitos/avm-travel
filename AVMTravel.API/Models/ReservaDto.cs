using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVMTravel.API.Models
{
    /// <summary>
    /// Clase que representa los datos de una reserva.
    /// </summary>
    public class ReservaDto
    {
        /// <summary>
        /// Obtiene o establece el identificador de la reserva.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la reserva.
        /// </summary>
        public DateTime FechaReserva { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tour asociado.
        /// </summary>
        public int TourId { get; set; }
    }
}