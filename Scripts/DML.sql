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
		('Milhouse Van Houten', 'milhouse@simpson',	1, 'milhouse1234'),

		('Marge Simpson', 'marge@simpson', 2, 'marge1234'),
		('Lisa Simpson', 'lisa@simpson', 2, 'lisa1234'),
		('Abe Simpson', 'vovo@simpson', 2, 'vovo1234'),
		('Apu Nahasapeemapetilon', 'apu@simpson', 2, 'apu1234'),
		('Reverendo Timothy Lovejoy', 'reverendo@simpson', 2, 'reverendo1234');
GO

INSERT INTO Medico (CRM, IdEspecialidade, IdUsuario)
	VALUES
		('123456789', 1, 6),
		('987654321', 2, 7),
		('456123789', 3, 8),
		('159753648', 4, 9),
		('147258369', 5, 10)
GO

INSERT INTO Paciente (Carteirinha, DataNascimento, Ativo, IdUsuario)
	VALUES
		('741852963', '1964-07-12',1, 1),
		('369258147', '2011-08-10',1, 2),
		('258741369', '2021-09-17',1, 3),
		('982145639', '1965-04-15',1, 4),
		('789512356', '2011-08-10',1, 5)
GO

INSERT INTO Consulta (IdMedico, IdPaciente, DataHora)
	VALUES
		(1, 1, '2022-10-01'),
		(2, 2, '2022-10-02'),
		(3, 3, '2022-10-03'),
		(4, 2, '2022-10-04'),
		(5, 3, '2022-10-05')
GO