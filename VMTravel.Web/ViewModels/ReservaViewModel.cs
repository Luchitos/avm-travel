using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVMTravel.Web.ViewModels
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public int TourId { get; set; } // Referencia al Tour
        public TourViewModel Tour { get; set; } // Información adicional del tour reservado
    }
}
