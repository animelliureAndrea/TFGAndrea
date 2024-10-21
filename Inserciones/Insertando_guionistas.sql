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
            ('esquemático', 'Drama', 'guionista1_instagram', '123456789', 1, 'Español', 2),
			('lineal', 'Comedia', 'guionista2_instagram', '987654321', 1, 'Inglés', 1),
			('esquemático', 'Acción', 'guionista3_instagram', '246813579', 0, 'Francés', 3),
			('lineal', 'Ciencia Ficción', 'guionista4_instagram', '135792468', 1, 'Italiano', 2),
			('esquemático', 'Romance', 'guionista5_instagram', '369258147', 1, 'Alemán', 1);
GO



