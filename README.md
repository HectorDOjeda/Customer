# # Customer API

Esta es una api que permite gestionar los datos de los clientes de una empresa. Está construida con .NET Core 6.0 y Entity Framework Core 6.0, usando SQLite como base de datos.

## Requisitos

Para ejecutar la api, necesitas tener instalado:

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQLite](https://www.sqlite.org/index.html)

## Instalación

Para instalar la api, sigue estos pasos:

1. Clona el repositorio usando el comando `git clone https://github.com/user/customer-api.git`.
2. Abre una terminal y navega al directorio del proyecto usando el comando `cd customer-api`.
3. Ejecuta el comando `dotnet restore` para restaurar las dependencias del proyecto.
4. Ejecuta el comando `dotnet ef database update` para crear la base de datos y la tabla de clientes.
5. Ejecuta el comando `dotnet run` para iniciar la api.

## Uso

La api expone los siguientes endpoints:

- `GET /api/customers`: Obtiene la lista de todos los clientes.
- `GET /api/customers/{id}`: Obtiene los datos de un cliente por su id.
- `POST /api/customers`: Crea un nuevo cliente con los datos enviados en el cuerpo de la petición.
- `PUT /api/customers/{id}`: Actualiza los datos de un cliente por su id con los datos enviados en el cuerpo de la petición.
- `DELETE /api/customers/{id}`: Elimina un cliente por su id.
