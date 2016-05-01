CREATE UNIQUE NONCLUSTERED INDEX [UX_Likes_UserId] 
	ON [dbo].[Likes] ([UserId] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_Likes_LikeableItemId] 
	ON [dbo].[Likes] ([LikeableItemId] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_SpecialOffers_Id] 
	ON [dbo].[SpecialOffers] ([Id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_SpecialOffers_PlaceId] 
	ON [dbo].[SpecialOffers] ([PlaceId] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_SpecialOffers_UserId] 
	ON [dbo].[SpecialOffers] ([UserId] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_Comments_Id] 
	ON [dbo].[LikeableItems] ([Id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_Comments_UserId] 
	ON [dbo].[Comments] ([UserId] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_Comments_PlaceId] 
	ON [dbo].[Comments] ([PlaceId] ASC);