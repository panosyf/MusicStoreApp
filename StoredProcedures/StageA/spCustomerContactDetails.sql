ALTER PROC spCustomerContactDetails
@DateFrom date = NULL,
@DateTo date = NULL
AS
BEGIN
BEGIN TRANSACTION
	SELECT c.CustomerId, c.Phone, c.Fax, c.Email, i.Total 'Total Income'
	FROM Customer c, Invoice i
	WHERE c.CustomerId = i.CustomerId
		AND(((NullIf(@DateFrom, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) >= @DateFrom)  
		AND ((NullIf(@DateTo, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) <= @DateTo))
	ORDER BY i.Total desc
COMMIT TRANSACTION
END
GO 1