using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVMTravel.Web.ViewModels
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }
}