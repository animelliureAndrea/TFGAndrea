USE [tfgCinPadd]
GO

INSERT INTO [dbo].[guiones]
           ([nombre]
           ,[guionista]
           ,[genero]
           ,[a�o]
           ,[sinopsis])
     VALUES
           ('El secreto de la monta�a', 1, 'Drama', '2022-05-15', 'Un grupo de excursionistas descubre un misterio oculto en lo m�s alto de una monta�a.'),
			('La sombra del pasado', 2, 'Suspenso', '2023-08-20', 'Un hombre es perseguido por su oscuro pasado mientras intenta reconstruir su vida.'),
			('El �ltimo viaje', 3, 'Aventura', '2024-04-10', 'Un grupo de amigos emprende un �pico viaje por carretera en busca de aventuras y descubrimientos.'),
			('La promesa rota', 4, 'Romance', '2023-11-05', 'Dos amantes se reencuentran despu�s de a�os separados, pero el destino tiene otros planes para ellos.'),
			('El experimento', 4, 'Ciencia Ficci�n', '2024-09-30', 'Un grupo de cient�ficos lleva a cabo un arriesgado experimento que podr�a cambiar el curso de la humanidad para siempre.');

GO


