using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AVMTravel.Core.Entities
{
    /// <summary>
    /// Clase que representa una reserva de un tour.
    /// </summary>
    public class Reserva
    {
        /// <summary>
        /// Obtiene o establece el identificador de la reserva.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente que realizó la reserva.
        /// </summary>
        [Required]
        public string Cliente { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se realizó la reserva.
        /// </summary>
        [Required]
        public DateTime FechaReserva { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tour reservado.
        /// </summary>
        [Required]
        public int TourId { get; set; }

        /// <summary>
        /// Tour reservado por el cliente.
        /// </summary>
        public virtual Tour Tour { get; set; }

        /// <summary>
        /// Muestra la información de la reserva, incluyendo los detalles del tour asociado.
        /// </summary>
        /// <returns>Información de la reserva como cadena de texto.</returns>
        public string MostrarInformacion()
        {
            return $"Reserva ID: {Id}\nCliente: {Cliente}\nFecha de Reserva: {FechaReserva.ToShortDateString()}\n" +
                   $"Tour Reservado: {Tour?.MostrarInformacion()}";
        }
    }
}
