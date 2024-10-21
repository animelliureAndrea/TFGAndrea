USE [tfgCinPadd]
GO

INSERT INTO [dbo].[castings]
           ([nombre]
           ,[descripcion]
           ,[director]
           ,[ubicaci�n]
           ,[interesados]
           ,[fecha]
           ,[codPelicula])
     VALUES
           ('Casting pel�cula acci�n', 'Se buscan actores y actrices con experiencia en escenas de acci�n.', 3, 'Estudio de cine XYZ', 1, '2024-02-15', 12),
			('Audici�n de talentos', 'Se convoca a una audici�n abierta para descubrir nuevos talentos.', 4, 'Teatro ABC', 1, '2024-04-20', NULL),
			('Casting pel�cula rom�ntica', 'Se buscan protagonistas para una historia de amor.', NULL, 'Estudio de cine XYZ', 1, '2024-06-10', 13),
			('Casting pel�cula terror', 'Buscamos actores dispuestos a enfrentarse a sus peores pesadillas.', NULL, 'Teatro del Terror', 1, '2023-10-05', 11),
			('Audici�n de doblaje', 'Se buscan voces talentosas para dar vida a los personajes de una pel�cula animada.', 5, 'Estudio de grabaci�n SoundWorks', 1, '2024-08-10', NULL);
GO


USE [tfgCinPadd]
GO

INSERT INTO [dbo].[castings]
           ([nombre]
           ,[descripcion]
           ,[director]
           ,[ubicaci�n]
           ,[interesados]
           ,[fecha]
           ,[codPelicula])
     VALUES
           ('Casting videoclip', 'Se buscan actores y actrices sin experiencia.', 3, 'Reservado Concept', 1, '2024-05-15', NULL),
			('Audici�n de ni�os', 'Se convoca a una audici�n abierta para nenes de 7-10.', 4, 'Teatro ABC', 1, '2024-04-20', NULL),
			('Casting pel�cula rom�ntica', 'Se buscan figurantes para una historia de amor.', 1, 'Estudio de cine XYZ', 1, '2024-06-10', 13),
			('Casting figurantes', 'Buscamos figurantes dispuestos a enfrentarse a sus peores pesadillas.', 2, 'Teatro del Terror', 1, '2023-10-05', 11),
			('Audici�n de extras', 'Se buscan extras de manos.', 5, 'Estudio de grabaci�n SoundWorks', 1, '2024-08-10', NULL);
GO