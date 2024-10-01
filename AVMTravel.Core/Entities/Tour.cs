using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AVMTravel.Core.Entities
{
    /// <summary>
    /// Clase que representa un tour disponible para reserva.
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Obtiene o establece el identificador del tour.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tour.
        /// </summary>
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el destino del tour.
        /// </summary>
        [Required]
        public string Destino { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio del tour.
        /// </summary>
        [Required]
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de fin del tour.
        /// </summary>
        [Required]
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Obtiene o establece el precio del tour.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public decimal Precio { get; set; }

        /// <summary>
        /// Muestra la información del tour.
        /// </summary>
        /// <returns>Información del tour como cadena de texto.</returns>
        public string MostrarInformacion()
        {
            return $"Tour: {Nombre}\nDestino: {Destino}\nFecha de Inicio: {FechaInicio.ToShortDateString()}\n" +
                   $"Fecha de Fin: {FechaFin.ToShortDateString()}\nPrecio: ${Precio}";
        }
    }
}
