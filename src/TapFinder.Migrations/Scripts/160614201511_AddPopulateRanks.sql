/* Migration Script */

CREATE TABLE [dbo].[Ranks](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Title] nvarchar(128) NOT NULL,
	[Description] nvarchar(512) NOT NULL,
);

GO
INSERT INTO [dbo].[Ranks]
           ([Title], [Description])
     VALUES
		(N'Początujący', N'Witaj na pokładzie!'),
		(N'Amator', N'Pierwsze wypite piwa za Tobą. Oby tak dalej!'),
		(N'Aspirujący', N'Aspirujesz do miana Piwosza, tak trzymać!'),
		(N'Piwosz', N'Lubisz wypić dobre piwo, może zostaniesz Browarnikiem?'),
		(N'Browarnik', N'Żadne kraftowe piwo nie jest Ci obce!'),
		(N'Ekspert', N'Jesteś prawdziwym ekspertem w kwestii złocistego trunku!')
;