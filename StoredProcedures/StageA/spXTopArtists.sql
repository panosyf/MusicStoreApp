ALTER PROC spXTopArtists
@TopX BIGINT =  9223372036854775807,
@DateFrom date = NULL,
@DateTo date = NULL
AS
BEGIN
BEGIN TRANSACTION
	SELECT TOP(@TopX) a.name 'Artist', sum(il.UnitPrice) 'Total Sales'
	FROM InvoiceLine il, Track t, Album al, Artist a, Invoice i
	WHERE il.TrackId = t.Trackid 
		AND al.AlbumId = t.AlbumId 
		AND a.ArtistId = al.ArtistId
		AND il.invoiceid = i.invoiceid
		AND(((NullIf(@DateFrom, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) >= @DateFrom)  
		AND ((NullIf(@DateTo, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) <= @DateTo))
	GROUP BY a.name
	ORDER BY 'Total Sales' Desc
COMMIT TRANSACTION
END
GO 1