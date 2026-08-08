USE VetNova
go

CREATE TABLE Propietarios(
	
	Id_Propietario              INT             IDENTITY(1,1)       NOT NULL,
    Id_Tipo_Identificacion      INT             NOT NULL,
    Identificacion              VARCHAR(100)    NOT NULL,
    Nombre                      VARCHAR(100)    NOT NULL,
    Apellido1                   VARCHAR(100)    NOT NULL,
    Apellido2                   VARCHAR(100)    NOT NULL,
    Telefono                    VARCHAR(100)    NOT NULL,
    Email                       VARCHAR(100)    NOT NULL,
    Direccion                   VARCHAR(100)    NOT NULL,
    Estado                      CHAR(1)         NOT NULL,

    CONSTRAINT PK_Propietarios PRIMARY KEY (Id_Propietario),

    CONSTRAINT FK_Propietarios_Tipos_Identificacion
        FOREIGN KEY (Id_Tipo_Identificacion)
        REFERENCES Tipos_Identificacion(Id_Tipo_Identificacion)
)