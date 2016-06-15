ALTER TABLE [dbo].[Ranks] 
ADD [MinExperience] int NOT NULL DEFAULT 0;

GO
UPDATE [dbo].[Ranks] SET [MinExperience] = 0 
WHERE [Id] = 1;

UPDATE [dbo].[Ranks] SET [MinExperience] = 50
WHERE [Id] = 2;

UPDATE [dbo].[Ranks] SET [MinExperience] = 100
WHERE [Id] = 3;

UPDATE [dbo].[Ranks] SET [MinExperience] = 200
WHERE [Id] = 4;

UPDATE [dbo].[Ranks] SET [MinExperience] = 500
WHERE [Id] = 5;

UPDATE [dbo].[Ranks] SET [MinExperience] = 1000
WHERE [Id] = 6;