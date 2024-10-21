USE [tfgCinPadd]
GO

INSERT INTO [dbo].[apariencia]
           ([codActor]
           ,[ojos]
           ,[etnia]
           ,[colorPelo]
           ,[largoPelo]
           ,[tipoPelo]
           ,[tinte]
           ,[tatoo]
           ,[piercing]
           ,[altura]
           ,[medidas])
     VALUES
		(1, 'Marrones', 'Caucasica', 'Negro', 'medio', 'liso', 1, 0, 0, '175 cm', '90-60-90'),
		(8, 'Azules', 'Asiatica', 'Rubio', 'largo', 'ondas', 0, 1, 0, '180 cm', '95-65-95'),
		(7, 'Verdes', 'Latina', 'Castano', 'corto', 'rizo', 0, 0, 1, '170 cm', '85-55-85'),
		(4, 'Cafés', 'Arabe', 'Negro', 'largo', 'liso', 1, 1, 0, '185 cm', '100-70-100'),
		(5, 'Gris', 'Gitana', 'Rubio', 'medio', 'rizo', 0, 0, 1, '165 cm', '80-50-80');
GO