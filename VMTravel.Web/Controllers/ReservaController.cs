using System.Web.Mvc;
using AVMTravel.Core.Interfaces;

[Authorize]
public class ReservaController : Controller
{
    private readonly IGestorReservasService _gestorReservasService;

    /// <summary>
    /// Constructor del controlador de reservas.
    /// </summary>
    /// <param name="gestorReservasService">Servicio de gestión de reservas inyectado.</param>
    public ReservaController(IGestorReservasService gestorReservasService)
    {
        _gestorReservasService = gestorReservasService;
    }

    /// <summary>
    /// Acción para mostrar todas las reservas.
    /// </summary>
    /// <returns>Vista con la lista de reservas.</returns>
    public ActionResult MostrarReservas()
    {
        var reservas = _gestorReservasService.MostrarReservas();
        return View(reservas);
    }

    /// <summary>
    /// Acción para eliminar una reserva por su ID.
    /// </summary>
    /// <param name="id">ID de la reserva a eliminar.</param>
    /// <returns>Redirige a la vista de todas las reservas.</returns>
    [HttpPost]
    public ActionResult EliminarReserva(int id)
    {
        _gestorReservasService.EliminarReserva(id);
        TempData["SuccessMessage"] = "Reserva eliminada con éxito.";
        return RedirectToAction("MostrarReservas");
    }
}
