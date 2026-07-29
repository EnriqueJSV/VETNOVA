USE VetNova
go

CREATE TABLE Auditoria(

    Id_Auditoria        INT             IDENTITY(1,1)       NOT NULL,
    Id_Usuario          INT             NOT NULL,
    Accion              CHAR(1)         NOT NULL,
    Descripcion         VARCHAR(500)    NOT NULL,
    Fecha               DATETIME        NOT NULL,
    

    CONSTRAINT PK_Auditoria PRIMARY KEY (Id_Auditoria),

    CONSTRAINT FK_Auditoria_Usuarios
        FOREIGN KEY (Id_Usuario)
        REFERENCES Usuarios(Id_Usuario)
)