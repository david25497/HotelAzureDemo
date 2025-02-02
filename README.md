# Hotel API

## Descripción
Este proyecto sirve como una muestra de mis conocimientos y habilidades en el desarrollo de aplicaciones backend orientadas a dominios.

## Tecnologías y Herramientas
- **Base de Datos**: MS SQL Server
- **ORM**: Entity Framework Core 8
- **Arquitectura**: Domain Oriented Architecture
- **Principios de Código**: Clean Code
- **Automapper**: AutoMapper para la transformación entre DTOs y modelos de dominio
- **Inyección de Dependencias**: Implementado para un código más modular y fácil de mantener
- **Control de Versiones**: GitHub
- **Manejo de Resultados y Errores**: ResultAPI y manejo de errores de base de datos (ErrorBD Handling)
- **DTO**: Data Transfer Objects para facilitar el paso de datos
- **Objetos de Valor**: Uso de Value Objects para entidades de dominio
- **Seguridad**: JSON Web Token (JWT) para autenticación
- **Patrón de Repositorio**: Para acceso estructurado a los datos
- **Despliegue**: Azure como plataforma para despliegue de la API

## Organización del Proyecto
El proyecto está estructurado en tres carpetas principales:

- `Core`: Contiene `Core.Application` y `Core.Domain`, donde se encuentran la lógica de negocio y los modelos de dominio.
- `Infrastructure`: Implementa la persistencia de datos y configuración de bases de datos.
- `Presentation`: Contiene `Presentation.API`, donde se implementa la API y se configuran los endpoints.

## Base de Datos
En el repositorio, encontrarás una carpeta llamada `BD` que contiene el archivo `BD HotelUltraGroup.sql`. Este script permite crear la base de datos junto con las tablas y los procedimientos almacenados necesarios para que la API funcione correctamente. Ejecutando este script en MS SQL Server, puedes obtener la estructura completa y reproducir el entorno de datos necesario para el proyecto.
