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
		(N'Pod��czony', N'Za�o�y�e� konto, cieszymy si�, �e jeste�!'),
		(N'Pierwsze piwo', N'Wypi�e� z TapFinder-em swoje pierwsze piwo.'),
		(N'Pierwsza promocja', N'Doda�e� do aplikacji pierwsz� promocj�. Gratulacje!'),
		(N'Aktywny', N'Doda�e� do aplikacji dziesi�� promocji! Oby tak dalej!'),
		(N'Piwosz', N'Wypi�e� z nasz� aplikacj� pierwsze dziesi�� piw. Gratulacje!')
;