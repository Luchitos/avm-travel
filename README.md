# avm-travel

Instrucciones:
Desarrollar una aplicación en ASP.NET (framework 4.5.2) y C#, con conexión a BD
utilizando Jquery o similar. El backend debe tener una API Rest o WCF con conexión a
BD usando EntityFramework.

Utiliza buenas prácticas de codificación y asegúrate de que el código sea modular y fácil
de entender. Se valora el uso adecuado de LINQ para realizar consultas sobre las listas
de tours y reservas.

Escenario:
Realizaremos un sistema de gestión de reservas de tours para una empresa de turismo.
Deberás implementar un sistema básico de Alta, Baja y Modificación (ABM) de reservas,
utilizando LINQ para realizar consultas sobre las reservas almacenadas.

Debe incluir un login con validación de usuario y contraseña.

A continuación, se describen los requisitos y las clases básicas que debes implementar.
Clases:
1. Tour
Propiedades: Id, Nombre, Destino, FechaInicio, FechaFin, Precio.
Métodos: MostrarInformacion() para mostrar la información del tour.
2. Reserva
Propiedades: Id, Cliente, FechaReserva, TourId (referencia al Tour reservado).

Métodos: MostrarInformacion() para mostrar la información de la reserva.
3. GestorReservas (Si se hace mediante API)
Debe contener una lista de tours y una lista de reservas.
Métodos:
AgregarTour(): Agrega un nuevo tour a la lista de tours.
MostrarTours(): Muestra la información de todos los tours.
ReservarTour(): Crea una reserva para el tour especificado y la agrega a la lista
de reservas.
MostrarReservas(): Muestra la información de todas las reservas.

Requisitos:
1. Crear Tours
Crea al menos tres instancias de la clase Tour con datos ficticios y agrégales al
gestor de reservas.
2. Mostrar Tours
Utiliza LINQ para mostrar la información de todos los tours.
3. Reservar Tours
Realiza al menos dos reservas utilizando el método ReservarTour en el gestor de
reservas.
4. Mostrar Reservas
Utiliza LINQ para mostrar la información de todas las reservas realizadas.
5. Eliminar Reserva
Implementa un método en el gestor de reservas que permita eliminar una
reserva específica por su Id.
