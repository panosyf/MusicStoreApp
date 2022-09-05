ALTER PROC spTopGenres
AS
BEGIN
BEGIN TRANSACTION
	SELECT g.name 'Genre', sum(il.TrackId) 'Total Purchases'
	FROM genre g, track t, InvoiceLine il, Invoice i
	WHERE g.GenreId = t.GenreId
	and il.TrackId = t.Trackid
	and il.invoiceid = i.invoiceid
	GROUP BY g.name
	ORDER BY 'Total Purchases' desc
COMMIT TRANSACTION
END
GO 1
