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

    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Spotify');
--IF ((SELECT COUNT(*) FROM StreamingPlatform) = 0) 
--BEGIN
    
--    INSERT INTO [SocialMediaPlatform]([Name]) VALUES ('Facebook');
--    INSERT INTO [SocialMediaPlatform]([Name]) VALUES ('X (Twitter)');

--    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Spotify');
--    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Apple Music');
--    INSERT INTO [StreamingPlatform]([Name]) VALUES ('Deezer');


--    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('SCH', 'Julien', null, null);
--    INSERT INTO [Artist] ([Id]) VALUES (1);
--    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (1,1, 'spot1');
--    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (1,2, 'apm1');
--    INSERT INTO [PersonSocialMediaPlatforms] ([PersonId], [SocialMediaPlatformId], [PersonSocialMediaPlatformId]) VALUES (1,1, 'fbsch1');


--    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('Scylla', 'Gilles', null, null);
--    INSERT INTO [Artist] ([Id]) VALUES (2);
--    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (2,1, 'spot2');
--    INSERT INTO [ArtistStreamingPlatforms] ([ArtistId], [StreamingPlatformId], [ArtistStreamingPlatformId]) VALUES (2,3, 'deez1');
--    INSERT INTO [PersonSocialMediaPlatforms] ([PersonId], [SocialMediaPlatformId], [PersonSocialMediaPlatformId]) VALUES (2,1, 'fbscy1');
--    INSERT INTO [PersonSocialMediaPlatforms] ([PersonId], [SocialMediaPlatformId], [PersonSocialMediaPlatformId]) VALUES (2,2, 'xscy1');


--    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('Furax Barbarossa', null, null, null);
--    INSERT INTO [Artist] ([Id]) VALUES (3);

--    INSERT INTO [Album] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Portes du désert', '455500', '2025-02-16');
--    INSERT INTO [ArtistAlbums] ([AlbumId], [ArtistId]) VALUES (1,2);
--    INSERT INTO [ArtistAlbums] ([AlbumId], [ArtistId]) VALUES (1,3);
--    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (1,1, 'portelkhepouespotify1');
--    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (1,2, 'porteapplenjkbks25dfy5497');

--    INSERT INTO [Track] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Caravanes', '30000', '2025-02-16');
--    INSERT INTO [ArtistTracks] ([ArtistId], [TrackId]) VALUES (2,1);
--    INSERT INTO [ArtistTracks] ([ArtistId], [TrackId]) VALUES (3,1);
--    INSERT INTO [AlbumTracks] ([AlbumId], [TrackId], [Position]) VALUES (1,1,5);

--    INSERT INTO [Track] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Loin', '25000', '2025-02-16');
--    INSERT INTO [ArtistTracks] ([ArtistId], [TrackId]) VALUES (2,2);
--    INSERT INTO [ArtistTracks] ([ArtistId], [TrackId]) VALUES (3,2);
--    INSERT INTO [AlbumTracks] ([AlbumId], [TrackId], [Position]) VALUES (1,2,9)



--    INSERT INTO [Album] ([Title], [DurationMs], [ReleaseDate]) VALUES ('Autobahn', '375500', '2019-05-08');
--    INSERT INTO [ArtistAlbums] ([AlbumId], [ArtistId]) VALUES (2,1);
--    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (2,1, 'Autobahn4856Spotify');
--    INSERT INTO [AlbumStreamingPlatforms] ([AlbumId], [StreamingPlatformId], [AlbumStreamingPlatformId]) VALUES (2,3, 'Autobahn54546Deezer');




--    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('Medhi Maïzi', 'Medhi', 'Maïzi', null);
--    INSERT INTO [Journalist] ([Id]) VALUES (4);
--    INSERT INTO [Person] (Pseudo, FirstName, LastName, ImageUrl) VALUES ('Le Rap en Mieux', 'Yannis', null, null);
--    INSERT INTO [ContentCreator] ([Id]) VALUES (5);




--    INSERT INTO [Video]([Title],[Url]) VALUES ('Analyse 1', 'http://analyse1')
--    INSERT INTO [Analyse]([Id],[ContentCreatorId]) VALUES (1, 5)
--    INSERT INTO [Video]([Title],[Url]) VALUES ('Analyse 2', 'http://analyse2')
--    INSERT INTO [Analyse]([Id],[ContentCreatorId]) VALUES (2, 5)


--    INSERT INTO [Video]([Title],[Url]) VALUES ('Interview 1', 'http://Interview1')
--    INSERT INTO [Interview]([Id],[JournalistId]) VALUES (3, 4)
--    INSERT INTO [Video]([Title],[Url]) VALUES ('Interview 2', 'http://Interview2')
--    INSERT INTO [Interview]([Id],[JournalistId]) VALUES (4, 4)

--    INSERT INTO [Video]([Title],[Url]) VALUES ('Clip 1', 'http://clip1')
--    INSERT INTO [Clip]([Id],[ArtistId]) VALUES (5, 1)
--    INSERT INTO [Video]([Title],[Url]) VALUES ('Clip 2', 'http://clip2')
--    INSERT INTO [Clip]([Id],[ArtistId]) VALUES (6, 2)
--END

