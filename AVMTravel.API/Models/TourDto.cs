using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVMTravel.API.Models
{
    /// <summary>
    /// Clase que representa los datos de un tour.
    /// </summary>
    public class TourDto
    {
        /// <summary>
        /// Obtiene o establece el identificador del tour.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tour.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el destino del tour.
        /// </summary>
        public string Destino { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio del tour.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de fin del tour.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Obtiene o establece el precio del tour.
        /// </summary>
        public decimal Precio { get; set; }
    }
}