USE Medical_Group;

INSERT INTO TipoDeUsuario
VALUES		('Médico'),
			('Paciente'),
			('ADM');
GO

INSERT INTO Usuario		(IdTipoDeUsuario , Email , Senha)
VALUES					(3				 , 'ADM@gmail.com' ,123456789),
						(1				 , 'Bruno@gmail.com' , 123456789),
						(2				 , 'Luis@gmail.com', 123456789),
						(2               , 'teste@gmail.com', 123)
GO


INSERT INTO Paciente	(IdUsuario,NomePaciente,RG,CPF,ENDEREÇO,DataDeNasc,Telefone)
VALUES					(3,'Luis',123456789,12345678901,'Rua Mercedes','1970-05-05 00:00:00:000',91231-2312),
						(4 ,'Jorge',123456,34634,'Paulista','1200-05-05 12:06:09:000',91231-2312);
go

INSERT INTO Situacao
VALUES					('Agendada'),
						('Cancelada'),
						('Feita');
GO

INSERT INTO Clinica	(Endereco, RazaoSocial,CNPJ,NomeFantasia)
VALUES				('Rua street 192','clínica médica SP Medical Group','1234567890123','SP Medical Grup');
GO

INSERT INTO Especialidade
VALUES		('Acupuntura'),
			('Anestesiologia'),
			('Angiologia'),
			('Cardiologia'),
			('Cirurgia Cardiovascular'),
			('Cirurgia da Mão'),
			('Cirurgia do Aparelho Digestivo'),
			('Cirurgia Geral'),
			('Cirurgia Pediátrica'),
			('Cirurgia Plástica'),
			('Cirurgia Torácica'),
			('Cirurgia Vascular'),
			('Dermatologia'),
			('Radioterapia'),
			('Urologia'),
			('Pediatria'),
			('Psiquiatria');
GO

INSERT INTO Medico	(IdUsuario,IdEspecialidade,IdClinica,RG,Endereco,DataDeNascimento,Telefone,NomeMedico)
VALUES				(2,13,1,'123456789','Rua casa 144','1971-04-04 00:00:00:000',2134-7890,'Bruno')	
GO

INSERT INTO Consulta(IdPaciente,IdMedico,IdSituacao,DataConsulta,Descricao)
VALUES	
	
	(1,1,3,'2000-12-10 14:55:00:000','Dor Muscular'),
	(1,1,3,'2011-01-09 19:23:00:000','Tosse'),
	(1,1,3,'1998-05-02 08:21:00:000','Febre Amarela'),
	(2,1,3,'2021-12-10 14:55:00:000','Vomito'),
	(2,1,3,'2018-01-09 19:23:00:000','Verme'),
	(2,1,3,'2009-05-02 08:21:00:000','Candidiase')
GO

SELECT * FROM Paciente