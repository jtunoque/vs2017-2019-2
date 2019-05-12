SELECT  C.TrackId, 
		C.Name AS TrackName, 
		C.AlbumId, 
		A.Title AS AlbumTitle, 
		C.MediaTypeId, 
		E.Name AS MediaTypeName, 
		C.GenreId, 
		D.Name AS GenreName, 
		C.Composer, 
		C.Milliseconds, 
        C.Bytes, 
		B.Name AS ArtistName,
		C.UnitPrice
FROM   dbo.Album AS A INNER JOIN
	dbo.Artist AS B ON A.ArtistId = B.ArtistId INNER JOIN
	dbo.Track AS C ON A.AlbumId = C.AlbumId INNER JOIN
	dbo.Genre AS D ON C.GenreId = D.GenreId INNER JOIN
	dbo.MediaType AS E ON C.MediaTypeId = E.MediaTypeId