USE VetNova
go

CREATE TABLE Tipos_Identificacion(

	Id_Tipo_Identificacion		INT				IDENTITY(1,1)		NOT NULL,
	Tipo_Identificacion			VARCHAR(50)		NOT NULL,
	Estado						CHAR(1)			NOT NULL,

	CONSTRAINT PK_Tipos_Identificacion PRIMARY KEY(Id_Tipo_Identificacion)
)