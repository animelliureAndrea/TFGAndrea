USE [tfgCinPadd]
GO

INSERT INTO [dbo].[usuarios]
           ([nombreUser]
           ,[contraseña]
           ,[correo]
           ,[nombre]
           ,[apellido1]
           ,[apellido2]
           ,[nacimiento]
           ,[nacionalidad]
           ,[codDirector]
           ,[codActor]
           ,[codGuionista]
           ,[codAficionado]
           ,[tipo])
     VALUES
           ('usuario1', 'contraseña1', 'usuario1@correo.com', 'Juan', 'González', 'López', '1990-05-15', 'Española', 1, NULL, NULL, NULL, 'director'),
			('usuario2', 'contraseña2', 'usuario2@correo.com', 'Emily', 'Smith', NULL, '1985-10-20', 'Británica', NULL, 8, NULL, NULL, 'actor'),
			('usuario3', 'contraseña3', 'usuario3@correo.com', 'Marie', 'Dupont', NULL, '1988-02-28', 'Francesa', NULL, NULL, 3, NULL, 'guionista'),
			('usuario4', 'contraseña4', 'usuario4@correo.com', 'Luca', 'Rossi', NULL, '1995-09-10', 'Italiana', NULL, 4, NULL, NULL, 'actor'),
			('usuario5', 'contraseña5', 'usuario5@correo.com', 'Hans', 'Müller', NULL, '1992-04-03', 'Alemana', 5, NULL, NULL, NULL, 'director');

GO


USE [tfgCinPadd]
GO

INSERT INTO [dbo].[usuarios]
           ([nombreUser]
           ,[contraseña]
           ,[correo]
           ,[nombre]
           ,[apellido1]
           ,[apellido2]
           ,[nacimiento]
           ,[nacionalidad]
           ,[codDirector]
           ,[codActor]
           ,[codGuionista]
           ,[codAficionado]
           ,[tipo])
     VALUES
			('director2', 'dir2', 'director2@correo.com', 'Raul', 'Martinez', null, '2000-09-22', 'Cipriota', 2, null, null, null, 'director'),
			('director3', 'dir3', 'director3@example.com', 'Cris', 'Cardio', null, '1990-01-01', 'Francés', 3, null, null, null, 'director'),
			('director4', 'dir4', 'director4@example.com', 'Sara', 'Arias', null, '1990-01-01', 'Italiana', 4, null, null, null, 'director'),
			('actor5', 'ac5', 'actor5@example.com', 'Marta', 'Arias', null, '1990-01-01', 'Inglesa', null, 5, null, null, 'actor'),
			('actor6', 'ac6', 'actor6@example.com', 'Silencio', 'A gritos', null, '1990-01-01', 'Francesa', null, 6, null, null, 'actor'),
			('actor7', 'ac7', 'actor7@example.com', 'Soledad', 'Arias', null, '1990-01-01', 'Italiana', null, 7, null, null, 'actor'),
			('aficionado3', 'aficionado3', 'aficionado3@example.com', 'Aitana', 'Ocaña', null, '1990-01-01', 'Español', null, null, null, 3, 'aficionado'),
			('aficionado4', 'aficionado4', 'aficionado4@example.com', 'Sebastian', 'Yatra', null, '1990-01-01', 'Español', null, null, null, 4, 'aficionado'),
			('aficionado5', 'aficionado5', 'aficionado5@example.com', 'Miguel', 'Bernardo', null, '1990-01-01', 'Español', null, null, null, 5, 'aficionado'),
			('aficionado6', 'aficionado6', 'aficionado6@example.com', 'Luis', 'Cepeda', null, '1990-01-01', 'Español', null, null, null, 6, 'aficionado'),
			('aficionado7', 'aficionado7', 'aficionado7@example.com', 'Ana', 'WAR', null, '1990-01-01', 'Español', null, null, null, 7, 'aficionado'),
			('guionista1', 'guion1', 'guion1@correo.com', 'Tim', 'Burton', NULL, '1988-02-28', 'Española', NULL, NULL, 1, NULL, 'guionista'),
			('guionista2', 'guion3', 'guion2@correo.com', 'Quevedo', 'Se fue', NULL, '1988-02-28', 'Inglesa', NULL, NULL, 2, NULL, 'guionista'),
			('guionista4', 'guion4', 'guion4@correo.com', 'Ela', 'Burton', NULL, '1988-02-28', 'Italiana', NULL, NULL, 4, NULL, 'guionista'),
			('guionista5', 'guion5', 'guion5@correo.com', 'Marisa', 'Burton', NULL, '1988-02-28', 'Alemana', NULL, NULL, 5, NULL, 'guionista');
GO

