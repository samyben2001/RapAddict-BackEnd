/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF ((SELECT COUNT(*) FROM StreamingPlatform) = 0) 
BEGIN
    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Spotify');
    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Apple Music');
    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Deezer');


    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('SCH', 'Julien', null, null);
    INSERT INTO [Artist] ([Id]) VALUES (1);
    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (1,1, 'spot1');
    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (1,2, 'apm1');


    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('Scylla', 'Gilles', null, null);
    INSERT INTO [Artist] ([Id]) VALUES (2);
    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (2,1, 'spot2');
    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (2,3, 'deez1');


    INSERT INTO [Album] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Portes du désert', '455500', '2025-02-16');
    INSERT INTO [ArtistAlbums] ([AlbumId], [ArtistId]) VALUES (1,2);
    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (1,1, 'portelkhepouespotify1');
    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (1,2, 'porteapplenjkbks25dfy5497');

    INSERT INTO [Track] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Caravanes', '30000', '2025-02-16');
    INSERT INTO [ArtistTracks] ([ArtistId], [TrackId]) VALUES (2,1);
    INSERT INTO [AlbumTracks] ([AlbumId], [TrackId], [Position]) VALUES (1,1,5);

    INSERT INTO [Track] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Loin', '25000', '2025-02-16');
    INSERT INTO [ArtistTracks] ([ArtistId], [TrackId]) VALUES (2,2);
    INSERT INTO [AlbumTracks] ([AlbumId], [TrackId], [Position]) VALUES (1,2,9)



    INSERT INTO [Album] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Autobahn', '375500', '2019-05-08');
    INSERT INTO [ArtistAlbums] ([AlbumId], [ArtistId]) VALUES (2,1);
    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (2,1, 'Autobahn4856Spotify');
    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (2,3, 'Autobahn54546Deezer');
END

