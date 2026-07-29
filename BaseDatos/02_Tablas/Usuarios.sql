USE VetNova
go

CREATE TABLE Usuarios(

    Id_Usuario          INT             IDENTITY(1,1)       NOT NULL,
    Id_Rol              INT             NOT NULL,
    Nombre_Usuario      VARCHAR(100)    NOT NULL,
    Email               VARCHAR(100)    NOT NULL,
    Contrasena          VARCHAR(100)    NOT NULL,
    Estado              CHAR(1)         NOT NULL,

    CONSTRAINT PK_Usuarios PRIMARY KEY (Id_Usuario),

    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (Id_Rol)
        REFERENCES Roles(Id_Rol)
)