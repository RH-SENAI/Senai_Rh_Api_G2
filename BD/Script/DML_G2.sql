USE SENAI_RH;
GO

INSERT INTO CEP(cep)
VALUES  ('01202001'),
		('05311020'),
		('08500400'),
		('05073000'),
		('79005420')
GO


INSERT INTO BAIRRO(nomeBairro)
VALUES  ('Campos Elíseos'),
		('Vila Leopoldina'),
		('Vila Romanópolis'),
		('Lapa'),
		('Amambaí')

GO

INSERT INTO CIDADE(nomeCidade)
VALUES  ('São Paulo'),
		('Ferraz de Vasconcelos'),
		('Campo Grande')
GO

INSERT INTO ESTADO(nomeEstado)
VALUES  ('SP'),
		('MS')
GO

INSERT INTO LOGRADOURO(nomeLogradouro)
VALUES  ('Alameda Barão de Limeira'),
		('Rua Jaguaré Mirim'),
		('Avenida Dom Pedro II'),
		('Rua Doze de Outubro'),
		('Rua Engenheiro Roberto Mange')
GO

INSERT INTO LOCALIZACAO(idCep, idBairro, idCidade, idEstado, idLogradouro, numero)
VALUES  (1, 1, 1, 1, 1, '539'),
		(2, 2, 1, 1, 2, '71'),
		(3, 3, 2, 1, 3, '33'),
		(4, 4, 1, 1, 4, '215'),
		(5, 5, 3, 2, 5, '194')
GO

INSERT INTO EMPRESA(idLocalizacao, nomeEmpresa, emailEmpresa, telefoneEmpresa, caminhoImagemEmpresa)
VALUES  (1, 'Senai Santa Cecilia', 'senaisc@gmail.com', '551132735000', 'foto'),
		(2, 'Senai Mariano Ferraz', 'senaimr@gmail.com', '551137381260', 'foto'),
		(3, 'McDonalds', 'mcDonalds@gmail.com', '551146742258', 'foto'),
		(4, 'Casas Bahia', 'casasbahia@gmail.com', '551123448000', 'foto'),
		(5, 'Senai Campo Grande', 'senaicg@gmail.com', '08007070745', 'foto')
GO