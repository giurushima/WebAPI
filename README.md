<h1><em>Proyecto para asignatura de Programacion III del tercer cuatrimestre de Tecnicatura Universitaria en Programacion (FRRo)</em></h1>

Gabriel Ignacio Urushima - @giurushima

Proyecto sobre desarrollo en asignatura de Programacion III para entrega final del Trabajo Practico Integrador. En el cual se aplican los conocimientos adquiridos vistos en el cursado y con material brindado por la catedra.

# Tecnologías y herramientas utilizadas:
- GIT
- GitHub
- .NET 6.0
- #C
- EntityFramework
- SQLite
- Visual Studio 2022 Community

# Requisitos para ejecutar programa.
- Cuenta de GitHub.
- Computadora con sistema operativo Windows.
- Visual Studio 2022.
- Configuracion de localhost apta para certificados y permisos.
- Navegador web.

# Paso a paso para ejecutar:
1. Descargar e instalar [Visual Studio 2022](https://visualstudio.microsoft.com/es/).
2. Descargar e instalar [GIT](https://git-scm.com/) y configurar con cuenta de [GitHub](https://github.com/).
3. Clonar repositorio de [Trucking](https://github.com/giurushima/Trucking.git).
4. EN CONSTRUCCION.

Authentication

| Metodo | Ruta | Descripcion |
|-----------------|----------------|----------------|
| POST | /api/authentication/authenticate | Autenticar a usuario por nombre de usuario y contraseña |

Trips

| Metodo | Ruta | Descripcion |
|-----------------|----------------|----------------|
| GET | /api/trips/{idTrucker}/trips | Devuelve los viajes de un chofer a traves de un ID |
| POST | /api/trips/{idTrucker}/trips | Crea un viaje para un chofer a traves de un ID |
| GET | /api/trips/{idTrucker}/trips/{idTrip} | Devuelve un viaje segun ID de chofer y ID de viaje |
| PUT | /api/trips/{idTrucker}/trips/{idTrip} | Actualiza un viaje segun ID de chofer y ID de viaje |
| DELETE | /api/trips/{idTrucker}/trips/{idTrip} | Borra un viaje segun ID de chofer y ID de viaje |

Truckers

| Metodo | Ruta | Descripcion |
|-----------------|----------------|----------------|
| GET | /api/truckers | Devuelve todos los choferes |
| POST | /api/truckers | Crea un nuevo chofer |
| GET | /api/truckers/{id} | Devuelve un chofer segun ID |
| PUT | /api/truckers/{id} | Actualiza/modifica un chofer segun ID |
| DELETE | /api/truckers/{id} | Borra un chofer segun ID |

Users

| Metodo | Ruta | Descripcion |
|-----------------|----------------|----------------|
| GET | /api/users | Devuelve todos los usuarios creados |
| POST | /api/users | Crea un nuevo usuario en el sistema |
| GET | /api/users/{id} | Devuelve un usuario segun ID |
| PUT | /api/users/{id} | Actualiza/modifica un usuario segun ID |
| DELETE | /api/users/{id} | Borra un usuario segun ID |
