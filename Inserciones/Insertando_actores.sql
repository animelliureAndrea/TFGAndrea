USE [tfgCinPadd]
GO

INSERT INTO [dbo].[actor]
           ([representante]
           ,[estudios]
           ,[instagram]
           ,[idiomaNacimiento]
           ,[numIdiomas]
           ,[telefono]
           ,[habilidad1]
           ,[habilidad2]
           ,[experiencia]
           ,[book]
           ,[videoBook])
     VALUES
         (1, 1, 'actor1_instagram', 'Espa�ol', 2, '123456789', 'baile', 'canto', 1, 1, 1),
		 (0, 1, 'actor2_instagram', 'Ingl�s', 1, '987654321', 'deporte', 'circo', 1, 1, 0),
		 (1, 0, 'actor3_instagram', 'Franc�s', 3, '246813579', 'baile', 'conducci�n', 0, 1, 1),
		 (0, 1, 'actor4_instagram', 'Italiano', 2, '135792468', 'canto', 'circo', 1, 0, 1),
		 (1, 1, 'actor5_instagram', 'Alem�n', 1, '369258147', 'deporte', 'conducci�n', 1, 1, 1);  
GO
