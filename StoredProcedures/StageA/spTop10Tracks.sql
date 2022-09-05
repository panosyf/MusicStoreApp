ALTER PROC spTop10Tracks
@DateFrom date = NULL,
@DateTo date = NULL
AS
BEGIN
BEGIN TRANSACTION
	SELECT TOP(10) t.name 'Track Name', sum(il.TrackId) 'Total Purchases'
	FROM track t, InvoiceLine il, Invoice i
	WHERE il.TrackId = t.Trackid
		AND il.invoiceid = i.invoiceid
		AND(((NullIf(@DateFrom, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) >= @DateFrom)  
		AND ((NullIf(@DateTo, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) <= @DateTo))
	GROUP BY t.name
	ORDER BY 'Total Purchases' desc
COMMIT TRANSACTION
END
GO 1