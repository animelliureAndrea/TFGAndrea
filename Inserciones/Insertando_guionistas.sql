USE [tfgCinPadd]
GO

INSERT INTO [dbo].[guionista]
           ([tipoEscritor]
           ,[generoPreferido]
           ,[instagram]
           ,[telefono]
           ,[experiencia]
           ,[idiomaNacimiento]
           ,[numIdiomas])
     VALUES
            ('esquem�tico', 'Drama', 'guionista1_instagram', '123456789', 1, 'Espa�ol', 2),
			('lineal', 'Comedia', 'guionista2_instagram', '987654321', 1, 'Ingl�s', 1),
			('esquem�tico', 'Acci�n', 'guionista3_instagram', '246813579', 0, 'Franc�s', 3),
			('lineal', 'Ciencia Ficci�n', 'guionista4_instagram', '135792468', 1, 'Italiano', 2),
			('esquem�tico', 'Romance', 'guionista5_instagram', '369258147', 1, 'Alem�n', 1);
GO



