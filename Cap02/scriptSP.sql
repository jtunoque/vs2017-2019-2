CREATE PROCEDURE usp_GetArtists
(
@FiltroPorNombre NVARCHAR(120)
)
AS
BEGIN
	SELECT ArtistId,Name 
	FROM Artist WHERE 
	Name LIKE @FiltroPorNombre
END

GO

--execute usp_InsertArtist 'Nuevo artista'

CREATE PROCEDURE usp_InsertArtist(
@Nombre NVARCHAR(120)
)
AS
BEGIN
	INSERT INTO Artist(Name)
	VALUES(@Nombre)

	SELECT SCOPE_IDENTITY()

END
