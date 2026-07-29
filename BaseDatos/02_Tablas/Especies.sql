USE VetNova
go

CREATE TABLE Especies(

	Id_Especie		INT				IDENTITY(1,1)		NOT NULL,
	Especie			VARCHAR(100)	NOT NULL,
	Estado			CHAR(1)			NOT NULL,

	CONSTRAINT PK_Especies PRIMARY KEY(Id_Especie)
)