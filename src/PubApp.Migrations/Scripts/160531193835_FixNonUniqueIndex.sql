DROP INDEX [UX_PlacesBeers_PlaceId] ON [dbo].[PlacesBeers];
CREATE NONCLUSTERED INDEX [IX_PlacesBeers_PlaceId] 
	ON [dbo].[PlacesBeers] ([PlaceId] ASC);