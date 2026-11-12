IF NOT EXISTS (SELECT name
               FROM   sys.databases
               WHERE  name = 'ProductosDB')
    BEGIN
        CREATE DATABASE ProductosDB;
    END


GO
USE ProductosDB;


GO
IF NOT EXISTS (SELECT *
               FROM   sys.objects
               WHERE  object_id = OBJECT_ID(N'[dbo].[Categoria]')
                      AND type IN (N'U'))
    BEGIN
        CREATE TABLE Categoria (
            Id          INT          IDENTITY (1, 1) PRIMARY KEY,
            Descripcion VARCHAR (50) NOT NULL
        );
    END


GO
IF NOT EXISTS (SELECT *
               FROM   sys.objects
               WHERE  object_id = OBJECT_ID(N'[dbo].[Producto]')
                      AND type IN (N'U'))
    BEGIN
        CREATE TABLE Producto (
            Id          INT             IDENTITY (1, 1) PRIMARY KEY,
            Nombre      VARCHAR (40)    NOT NULL,
            Precio      DECIMAL (18, 2) NOT NULL,
            CategoriaID INT             NOT NULL,
            CONSTRAINT FK_Producto_Categoria FOREIGN KEY (CategoriaID) REFERENCES Categoria (Id)
        );
    END


GO
SET IDENTITY_INSERT Categoria ON;

IF NOT EXISTS (SELECT 1
               FROM   Categoria
               WHERE  Id = 1)
    INSERT  INTO Categoria (
        Id,
        Descripcion
    )
    VALUES                 (1, 'Bebidas');

IF NOT EXISTS (SELECT 1
               FROM   Categoria
               WHERE  Id = 2)
    INSERT  INTO Categoria (
        Id,
        Descripcion
    )
    VALUES                 (2, 'Limpieza');

IF NOT EXISTS (SELECT 1
               FROM   Categoria
               WHERE  Id = 3)
    INSERT  INTO Categoria (
        Id,
        Descripcion
    )
    VALUES                 (3, 'Electrodomésticos'); -- Categoria sin productos

SET IDENTITY_INSERT Categoria OFF;


GO
SET IDENTITY_INSERT Producto ON;

IF NOT EXISTS (SELECT 1
               FROM   Producto
               WHERE  Id = 1)
    INSERT  INTO Producto (
        Id,
        Nombre,
        Precio,
        CategoriaID
    )
    VALUES                (1, 'Coca Cola 2L', 2200.00, 1);

IF NOT EXISTS (SELECT 1
               FROM   Producto
               WHERE  Id = 2)
    INSERT  INTO Producto (
        Id,
        Nombre,
        Precio,
        CategoriaID
    )
    VALUES                (2, 'Agua Mineral 1.5L', 1100.00, 1);

IF NOT EXISTS (SELECT 1
               FROM   Producto
               WHERE  Id = 3)
    INSERT  INTO Producto (
        Id,
        Nombre,
        Precio,
        CategoriaID
    )
    VALUES                (3, 'Detergente 750ml', 1850.50, 2);

SET IDENTITY_INSERT Producto OFF;