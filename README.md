# Travel Search Application

Una aplicación web desarrollada en **ASP.NET Core 9 MVC** que permite a los usuarios buscar y visualizar opciones de viajes, incluyendo vuelos y hoteles.

## Descripción del Proyecto

Esta aplicación de viajes está diseñada para proporcionar una experiencia completa de búsqueda y visualización de opciones de viaje. Los usuarios pueden buscar vuelos y hoteles, comparar opciones y obtener información detallada para tomar decisiones informadas sobre sus viajes.

### Objetivos Principales

- Facilitar la búsqueda de vuelos con criterios básicos y avanzados
- Permitir la búsqueda de hoteles por destino y fechas
- Proporcionar visualización clara y organizada de resultados
- Ofrecer herramientas de filtrado y comparación

## Funcionalidades Principales

La aplicación está estructurada en dos epics principales con sus respectivas features y user stories:

### 🔍 Epic 1: Búsqueda de Viajes

#### Feature: Búsqueda de Vuelos
- **US-001: Búsqueda básica de vuelos**
  - Búsqueda por origen, destino y fechas
  - Soporte para viajes de ida y vuelta
  - Validación de campos y fechas
  - Autocompletado de ciudades/aeropuertos

- **US-002: Filtros avanzados de búsqueda**
  - Filtros adicionales para personalizar la búsqueda
  - Opciones de ordenamiento y refinamiento

#### Feature: Búsqueda de Hoteles
- **US-003: Búsqueda de hoteles**
  - Búsqueda por destino, fechas de check-in/check-out
  - Especificación de número de huéspedes y habitaciones
  - Autocompletado de destinos
  - Opción de búsqueda por geolocalización

### 📊 Epic 2: Visualización de Resultados

#### Feature: Visualización de Vuelos
- **US-004: Lista de resultados de vuelos**
  - Información detallada: precio, aerolínea, horarios, duración
  - Múltiples opciones de ordenamiento
  - Indicación clara de escalas y servicios incluidos
  - Paginación de resultados

- **US-005: Filtros y búsqueda avanzada**
  - Filtros dinámicos para refinar resultados
  - Búsqueda avanzada con múltiples criterios

- **US-006: Detalle de vuelo**
  - Vista detallada de información específica del vuelo
  - Información completa sobre servicios y condiciones

#### Feature: Visualización de Hoteles
- **US-007: Lista de resultados de hoteles**
  - Listado organizado de opciones de alojamiento
  - Información detallada de cada hotel
  - Opciones de filtrado y ordenamiento

## Tecnologías Utilizadas

- **Framework**: ASP.NET Core 9 MVC
- **Arquitectura**: Modelo-Vista-Controlador (MVC)
- **Frontend**: Razor Views con HTML5, CSS3, JavaScript
- **Backend**: C# con .NET 9

## Estructura del Proyecto

El proyecto sigue el patrón MVC con la siguiente organización:

```
/Controllers     - Controladores para manejar las peticiones HTTP
/Models         - Modelos de datos y lógica de negocio  
/Views          - Vistas Razor para la interfaz de usuario
/wwwroot        - Archivos estáticos (CSS, JS, imágenes)
/Services       - Servicios para lógica de negocio
```

## Getting Started

### Prerrequisitos

- .NET 9 SDK o superior
- Visual Studio 2022 o Visual Studio Code
- SQL Server (LocalDB para desarrollo)

### Instalación

1. Clonar el repositorio
```bash
git clone https://dev.azure.com/amr-organization/demo-mcp-devops-server/_git/webapp-mvc-demo-travel
cd webapp-mvc-demo-travel
```

2. Restaurar las dependencias
```bash
dotnet restore
```

3. Ejecutar la aplicación
```bash
dotnet run
```

4. Abrir el navegador en `https://localhost:5001`

## Build and Test

### Construcción del Proyecto
```bash
dotnet build
```

### Ejecutar Tests
```bash
dotnet test
```

### Publicación
```bash
dotnet publish -c Release
```

## Contribute

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Enlaces de Referencia

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Azure DevOps](https://dev.azure.com/amr-organization/demo-mcp-devops-server/)
- [.NET 9 Documentation](https://docs.microsoft.com/en-us/dotnet/)