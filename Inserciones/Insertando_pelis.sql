USE [tfgCinPadd]
GO

INSERT INTO [dbo].[peliculas]
           ([titulo]
           ,[descripcion]
           ,[n�Actores]
           ,[director]
           ,[guionista]
           ,[guion]
           ,[genero]
           ,[a�o])
     VALUES
           ('El secreto de la monta�a', 'Un grupo de excursionistas descubre un misterio oculto en lo m�s alto de una monta�a.', 6, 1, 1, 1, 'Drama', '2022-05-15'),
			('La sombra del pasado', 'Un hombre es perseguido por su oscuro pasado mientras intenta reconstruir su vida.', 4, 2, 2, 2, 'Suspenso', '2023-08-20'),
			('El �ltimo viaje', 'Un grupo de amigos emprende un �pico viaje por carretera en busca de aventuras y descubrimientos.', 8, 3, 3, 3, 'Aventura', '2024-04-10'),
			('La promesa rota', 'Dos amantes se reencuentran despu�s de a�os separados.', 5, 4, 4, 4, 'Romance', '2023-11-05'),
			('El experimento', 'Un grupo de cient�ficos lleva a cabo un arriesgado experimento.', 7, 5, 5, 5, 'Ciencia Ficci�n', '2024-09-30');
GO

USE [tfgCinPadd]
GO

INSERT INTO [dbo].[peliculas]
           ([titulo]
           ,[descripcion]
           ,[n�Actores]
           ,[director]
           ,[guionista]
           ,[guion]
           ,[genero]
           ,[a�o])
     VALUES
		('No hay pel�cula', 'Campo enlazado a casting sin pel�cula relaccionada', 0, 1, 1, 1, 'Drama', '2022-05-15');
GO
