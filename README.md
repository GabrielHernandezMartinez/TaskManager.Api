# TaskManager API - Sistema de Gestión de Tareas

Esta es una Web API desarrollada en .NET 8 diseñada para gestionar tareas pendientes de forma eficiente. El sistema incluye una base de datos local y lógica inteligente para la clasificación automática de prioridades.

## Características Principales

* CRUD Completo: Creación, lectura, actualización y eliminación de tareas.

* Persistencia de Datos: Uso de SQLite con Entity Framework Core para el almacenamiento local.

* Lógica Inteligente: Asignación automática de prioridad "Alta" si la descripción contiene la palabra "urgente".

* Validación de Negocio: El sistema impide la creación de tareas con fechas de vencimiento pasadas.

* Documentación Interactiva: Implementación de Swagger para pruebas rápidas de los endpoints.

* Aseguramiento de Calidad: Suite de pruebas unitarias desarrolladas con xUnit.

## Tecnologías Utilizadas

* Backend: .NET 8 (C#).

* Base de Datos: SQLite.

* ORM: Entity Framework Core.

* Pruebas: xUnit.

* Documentación: Swagger/OpenAPI.

## Instrucciones de Ejecución

1. Requisitos previos
Tener instalado el SDK de .NET 8 o superior.

2. Clonar y preparar
PowerShell
# Restaurar dependencias
dotnet restore
3. Ejecutar la API
PowerShell
dotnet run --project TaskManager.Api/TaskManager.Api.csproj
La API estará disponible en: https://localhost:7165/swagger/index.html (o el puerto configurado localmente).

4. Ejecutar Pruebas Unitarias
PowerShell
dotnet test trabajo.slnx
Este comando validará la lógica de prioridades y fechas.

## Decisiones Técnicas
* Estructura del proyecto:
Se utilizo una estructura de solucion .NET con proyectos separados para la api y los test. Esto permite la escalabilidad y mantiene el codigo limpio y organizado.
* Patrones de diseño: Se aplico el MVC y el patron de inyecciones de dependencias para la base de datos, lo que facilita el mantenimiento.
* Persistencia de los datos: Se utilizo Entity Framework Core con el enfoque Code-First. Esto permite que la base de datos se genere y actualize de manera automatica a partir de la clase de C#, simplificando el despliegue.
