USE VetNova
go

CREATE TABLE Especialidades(
	Id_Especialidad		int				IDENTITY(1,1)		NOT NULL,
	Especialidad		VARCHAR(50)		NOT NULL,
	Estado				CHAR(1)			NOT NULL,

	CONSTRAINT PK_Especialidades PRIMARY KEY(Id_Especialidad)
)