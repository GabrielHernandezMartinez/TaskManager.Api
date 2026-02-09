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
