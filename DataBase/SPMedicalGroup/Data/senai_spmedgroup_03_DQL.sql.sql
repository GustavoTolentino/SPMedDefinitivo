USE Medical_Grup_;

SELECT Consulta.IdConsulta , Clinica.Endereco AS Endere?o , Clinica.RazaoSocial AS Cl?nica ,
Medico.NomeMedico , Especialidade.Especialidades , Paciente.NomePaciente , Paciente.RG , Situacao.TipoSituacao AS Situa??o ,
Consulta.DataConsulta , Consulta.Descricao AS Descri??o , Consulta.Exames FROM Consulta

INNER JOIN Medico
ON Consulta.IdMedico = Medico.IdMedico
INNER JOIN Especialidade
ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Clinica
ON Medico.IdClinica = Clinica.IdClinica
INNER JOIN Situacao
ON Consulta.IdSituacao = Situacao.IdSituacao
INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdConsulta;


SELECT Usuario.IdUsuario , TipoDeUsuario.IdTipoDeUsuario ,
Usuario.Email FROM Usuario

INNER JOIN TipoDeUsuario
ON Usuario.IdTipoDeUsuario = TipoDeUsuario.IdTipoDeUsuario;


SELECT Paciente.IdPaciente , Paciente.NomePaciente , Usuario.Email ,Paciente.RG ,
Paciente.CPF , Paciente.ENDERE?O AS Endere?o ,
Paciente.DataDeNasc AS DataDeNascimento , Paciente.Telefone FROM Paciente

INNER JOIN Usuario
ON Paciente.IdUsuario = Usuario.IdUsuario;


SELECT Medico.IdMedico , Medico.NomeMedico , Especialidade.Especialidades ,
Medico.RG , Medico.Endereco AS Endere?o , Medico.DataDeNascimento , Medico.Telefone ,
Clinica.RazaoSocial AS Cl?nica , Clinica.Endereco AS Endere?o FROM Medico

INNER JOIN Especialidade
ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Clinica
ON Medico.IdClinica = Clinica.IdClinica;