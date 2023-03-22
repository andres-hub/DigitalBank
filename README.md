# DigitalBank
Prueba arquitectura en capas

1. Clone el proyecto
2. En el archivo  UsuarioRepository de la capa de datos, ingrese la conexión  de la base de datos, en la variable connString que se encuentra en la línea 11.
3. En su motor de base de datos, ejecute los siguientes querys 
  - Crear la base de datos
  ```
   CREATE DATABASE [demo]
  ```
  - Crear Tabla Usuarios
  ```
  CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NULL,
	[Sexo]  [varchar](1) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO
  ```
  - Crear procedimiento de almacenado Agregar Usuario
  ```
  CREATE PROCEDURE AgregarUsuario   
    @Nombre varchar(100),   
    @FechaNacimiento datetime,   
    @Sexo varchar(1)   
AS   

  INSERT INTO [dbo].[Usuario]
           ([Nombre]
           ,[FechaNacimiento]
           ,[Sexo])
     VALUES
           (@Nombre, @FechaNacimiento
           ,@Sexo)
GO 

```
- Crear procedimiento de almacenado Eliminar Usuario
```
CREATE PROCEDURE EliminarUsuario   
    @IdUsuario int  
AS   

 DELETE Usuario WHERE Id = @IdUsuario
GO 
```
- Crear procedimiento de almacenado Modificar Usuario
```
CREATE PROCEDURE ModificarUsuario   
    @Id int,  
	@Nombre varchar(100),   
    @FechaNacimiento datetime,   
    @Sexo varchar(1) 
AS  
 UPDATE Usuario set Nombre = @Nombre,  FechaNacimiento =  @FechaNacimiento, Sexo = @Sexo WHERE Id = @Id
GO 

```
