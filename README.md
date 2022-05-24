# frutas-api

## Sobre la api
Api creada en Net Core 3.1 con swagger incluido, autenticación con JWT y base de datos en memoria usando Entity Framework Core. 

### Autenticación
Para consultar los métodos se debe obtener el token de acceso (bearer token) consultando el endpoint ![image](https://user-images.githubusercontent.com/8540060/169947339-f2bf6c94-46f8-4c16-86da-3d76b4c900b9.png)

## Servicios
La Api cuenta con 2 servicios Fruits y Users
### Fruits
Incluye 5 endpoints para crear, actualizar, eliminar, obtener por id y listar las frutas. Para ejecutar los métodos es necesaria la autenticación. 

 ![image](https://user-images.githubusercontent.com/8540060/169947882-485f195b-74ed-466c-98b2-25147278ae83.png)

### Users
Incluye 2 endpoints para crear y listar usuarios que requieren autenticación. Además de un método para realizar la autenticación

![image](https://user-images.githubusercontent.com/8540060/169948272-5cd6236b-ea99-4437-a47c-453cfe90c07d.png)

### Usuario inicial
**Para poder consultar los endpoints se ha creado un usuario con el que iniciar sesión.**

**user: admin <br> password: 123456**









