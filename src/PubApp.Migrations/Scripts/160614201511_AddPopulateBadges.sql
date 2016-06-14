/* Migration Script */

CREATE TABLE [dbo].[Badges](
	[Id] int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Title] nvarchar(128) NOT NULL,
	[Description] nvarchar(512) NOT NULL,
);

CREATE TABLE [dbo].[UsersBadges](
	[UserId] int NOT NULL,
	[BadgeId] int NOT NULL,
	
	CONSTRAINT [PK_UsersBadges] PRIMARY KEY CLUSTERED ([UserId] ASC, [BadgeId] ASC),
	CONSTRAINT [FK_UsersBadges_AspNetUsers] FOREIGN KEY(UserId) REFERENCES [dbo].AspNetUsers(Id),
	CONSTRAINT [FK_UsersBadges_Badges] FOREIGN KEY(BadgeId) REFERENCES [dbo].Badges(Id)
);

GO
INSERT INTO [dbo].[Badges]
           ([Title], [Description])
     VALUES
		(N'Pocz¹tuj¹cy', N'Witaj na pok³adzie!'),
		(N'Amator', N'Pierwsze wypite piwa za Tob¹. Oby tak dalej!'),
		(N'Aspiruj¹cy', N'Aspirujesz do miana Piwosza, tak trzymaæ!'),
		(N'Piwosz', N'Lubisz wypiæ dobre piwo, mo¿e zostaniesz Browarnikiem?'),
		(N'Browarnik', N'¯adne kraftowe piwo nie jest Ci obce!'),
		(N'Ekspert', N'Jesteœ prawdziwym ekspertem w kwestii z³ocistego trunku!')
;