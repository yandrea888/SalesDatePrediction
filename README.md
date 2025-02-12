El proyecto principal está construido en .NET 8.0, su nombre es SalesDatePrediction.Api
Dicho proyecto tiene seis capas principales:

📂 SalesDatePrediction.Api
  📂 Controllers          			-> Controladores Web API 
  📂 Dtos                 			-> Objetos de transferencia de datos 
  📂 Repositories         			-> Repositorios para acceder a la base de datos
  📂 Services             			-> Lógica de negocio
  📂 SalesDatePrediction.Tests        	-> Proyecto para pruebas unitarias
  📂 SalesDatePredictionApp        	-> Proyecto para front en Angular

En el proyecto se usaron los principiso solid de la siguiente manera: 

S – Single Responsibility Principle (SRP)
Cada clase tiene una sola responsabilidad:

Controller: Gestiona las solicitudes HTTP y devuelve las respuestas.
Service: Contiene la lógica de negocio (reglas, validaciones).
Repository: Se encarga exclusivamente del acceso a la base de datos.

O – Open/Closed Principle (OCP)
Las clases están abiertas para extensión, pero cerradas para modificación.

Por ejemplo con los servicios; puedes extender su funcionalidad sin alterar el controlador.

D – Dependency Inversion Principle (DIP)
Estoy inyectando las dependencias (por ejempolo en EmpleadoRepository y EmpleadoService) a través del constructor, en lugar de crearlas directamente en las clases (new).
Esto hace que el código sea más flexible y testeable. Además, permite cambiar la implementación de esas dependencias sin modificar el controlador o el servicio.

El proyecto se ejecuta abriendo el archivo **SalesDatePrediction.Api.sln** en **Visual Studio 2022**.  

Para ejecutarlo:  
1. Abre **Visual Studio 2022**.  
2. Ve a **Archivo > Abrir > Proyecto/Solución**.  
3. Selecciona el archivo `SalesDatePrediction.Api.sln`.  
4. Una vez cargado, presiona `F5` o haz clic en el botón **Ejecutar** para iniciar la aplicación.  

API Endpoints: 

Al ejecutar el proyecto, la API se abre automáticamente en la siguiente ruta:

Swagger UI: http://localhost:5189/swagger/index.html

A continuación, se detallan los endpoints disponibles:

Cliente
GET /api/Cliente – Obtiene la lista de clientes.
Customer
GET /api/Customer – Obtiene la lista de clientes (creado para realizar las pruebas unitarias).
Empleado
GET /api/Empleado – Obtiene la lista de empleados.
Orden
GET /api/Orden/{customerId} – Obtiene las órdenes de un cliente específico.
OrdenNueva
POST /api/OrdenNueva – Crea una nueva orden.
Producto
GET /api/Producto – Obtiene la lista de productos.
Transportista
GET /api/Transportista – Obtiene la lista de transportistas.

Pruebas Unitarias

En el proyecto SalesDatePrediction.Tests, se implementaron pruebas unitarias utilizando xUnit para validar el comportamiento de los controladores de la API.

Pruebas Implementadas:
Se logró implementar una prueba para el controlador CustomerController:
GetCustomers_ReturnsListOfCustomers
Verifica que el método GetCustomers devuelva una lista de clientes y se asegura que la respuesta sea un OkObjectResult con una lista no vacía de clientes.

Pruebas Pendientes
Por falta de tiempo y experiencia en pruebas unitarias, no logré completar las pruebas para los otros controladores (EmpleadoController, OrdenController, etc.). Sin embargo, se la estructura y enfoque utilizados en la prueba realizada pueden servir de base para futuras implementaciones.


Proyecto Frontend en Angular: SalesDatePredictionApp

Angular CLI: 19.1.6
Node: 18.20.4
Package Manager: npm 10.7.0
OS: win32 x64

Descripción
Este proyecto es un frontend desarrollado en Angular que permite gestionar clientes y órdenes de compra. Se conecta con una API REST para obtener datos de clientes y crear nuevas órdenes.

Tecnologías utilizadas
Framework: Angular 19.1.5
Lenguaje: TypeScript
Gestión de paquetes: npm
Servidor HTTP: Angular CLI
Manejo de formularios: Reactive Forms
Cliente HTTP: HttpClientModule
Ruteo: Angular Router
Paginación: ngx-pagination
Estilos: Angular Material
Formatos de fecha: DatePipe

Estructura del Proyecto:

ClienteService: Servicio que se encarga de obtener los clientes desde la API.
NuevaOrdenComponent: Formulario para crear una nueva orden con validaciones y envío de datos al backend.
ClienteComponent: Componente para listar clientes, buscar y ordenar resultados, y navegar a órdenes.
OrdenListComponent: Componente que muestra la lista de órdenes de un cliente seleccionado.

Funcionalidades Implementadas:

Búsqueda de clientes: Permite filtrar clientes por nombre utilizando HttpParams (se intentó pero me falla la búsqueda)
Ordenación de datos: Se puede ordenar la lista de clientes por cualquier columna.
Paginación: Implementada con ngx-pagination para mejorar la experiencia de usuario.
Creación de órdenes: Formulario reactivo con validaciones para agregar productos a una orden.
Manejo de rutas: Se utiliza Router para navegar entre componentes.

Instalación y Ejecución
Instalar dependencias con:npm install
Ejecutar el servidor Angular: ng serve
Acceder a la aplicación en http://localhost:4200.


Esta es mi prueba, traté de realizar todo lo solicitado, me hubiera gustado realizar todo el proyecto de pruebas y que el botón de búsqueda me funcionara, y lo voy a seguir trabajando, en el repositorio verán los avances en estos temas (es un reto y me encantan los retos), pero hago la entrega para cumplir con el tiempo pactado. 

Aclaración: había olvidado subir los scripts sql para el segundo punto de la prueba, ya están en el repositorio, aunque en la carpeta repositories estaban para efectos de la aplicación, Mil discúlpas.

Mil gracias

Yuly Andrea Morales

