# Car Catalog API

## Requisitos

- .NET SDK 7.0+
- SQL Server 
- Visual Studio / Visual Studio Code

## Configuración

1. Clonar el repositorio
2. Configurar la cadena de conexión en `appsettings.json`
3. Ejecutar las migraciones para crear las tablas:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
