USE DesafioEntityFramework;
GO

  INSERT INTO TipoUsuario (Tipo)
	VALUES
		('Paciente'),
		('Medico')
GO
INSERT INTO Especialidade (Categoria)
	VALUES
		('Clínica(o) Geral'),
		('Cardiologista'),
		('Ortopedista'),
		('Neurologista'),
		('Otorrinolaringologista'),
		('Gastroenterologia'),
		('Endocrinologista')
GO

INSERT INTO Usuario(Nome, Email, IdTipoUsuario, Senha) /* Jogadores e seus dados de cadastro*/
	VALUES	
		('Homer Simpson', 'homer@simpson', 1, 'homer1234'),
		('Bart Simpson', 'bart@simpson', 1, 'bart1234'),
		('Maggie Simpson', 'maggie@simpson', 1, 'maggie1234'),
		('Ned Flanders', 'ned@simpson', 1, 'ned1234'),
		('Otto Man', 'otto@simpson',	1, 'otto123456'),
		('Lenny Leonard', 'lenny@simpson',	1, 'lenny123456'),
		('Barney Gumble', 'barney@simpson',	1, 'barney123456'),
		('Moe Szyslak', 'moe@simpson',	1, 'moe123456'),
		('Montgomery Burns', 'reverendo@simpson', 1, 'reverendo1234'),
		
		--10
		('Marge Simpson', 'marge@simpson', 2, 'marge1234'),
		('Lisa Simpson', 'lisa@simpson', 2, 'lisa1234'),
		('Abe Simpson', 'vovo@simpson', 2, 'vovo1234'),
		('Apu Nahasapeemapetilon', 'apu@simpson', 2, 'apu1234'),
		('Waylor Smithers', 'smithers@simpson', 2, 'smithers123456'),
		('Chefe Wiggum', 'wiggum@simpson', 2, 'wiggum123456'),
		('Krusty o plalhaço', 'krusty@simpson', 2, 'krusty12346'),
		('Sideshow Bob', 'bob@simpson', 2, 'bob123456'),
		('Diretor Seymour Skinner', 'skinner@simpson',	2, 'skinner123456')
		
GO

INSERT INTO Medico (CRM, IdEspecialidade, IdUsuario)
	VALUES
		('123456789', 1, 10),
		('987654321', 2, 11),
		('456123789', 3, 12),
		('159753648', 4, 13),
		('456789951', 5, 14),
		('159456753', 6, 15),
		('652145785', 7, 16),
		('985452012', 1, 17),
		('456032189', 2, 18)
GO

INSERT INTO Paciente (Carteirinha, DataNascimento, Ativo, IdUsuario)
	VALUES
		('741852963', '1964-07-12',1, 1),
		('369258147', '2011-08-10',1, 2),
		('258741369', '2021-09-17',1, 3),
		('982145639', '1965-04-15',1, 4),
		('789512356', '1995-05-14',1, 5),
		('456132052', '1965-07-25',1, 6),
		('789437934', '1960-06-07',1, 7),
		('125423658', '1965-04-09',1, 8),
		('951032698', '1900-03-12',1, 9)
GO

INSERT INTO Consulta (IdMedico, IdPaciente, DataHora)
	VALUES
		(1, 1, '2022-10-01'),
		(2, 2, '2022-10-02'),
		(3, 3, '2022-10-03'),
		(4, 2, '2022-10-04'),
		(5, 3, '2022-10-05'),
		(6, 4, '2022-10-06'),
		(7, 5, '2022-10-07'),
		(8, 5, '2022-10-08'),
		(9, 4, '2022-10-09'),
		(1, 6, '2022-10-10'),
		(2, 7, '2022-10-11'),
		(3, 7, '2022-10-12'),
		(4, 6, '2022-10-13'),
		(5, 8, '2022-10-14'),
		(6, 9, '2022-10-15'),
		(6, 9, '2022-10-16'),
		(6, 8, '2022-10-17')
GO