ALTER PROC spOrderDetails
@DateFrom date = NULL,
@DateTo date = NULL,
@EmployeeFN nvarchar(50) = NULL,
@EmployeeLN nvarchar(50) = NULL,
@CustomerFN nvarchar(50) = NULL,
@CustomerLN nvarchar(50) = NULL
AS
BEGIN
BEGIN TRANSACTION
	SELECT i.InvoiceId, c.FirstName 'Customer FirstName', c.LastName 'Customer LastName',
		e.FirstName 'Employee FirstName', e.LastName 'Employee LastName'
	FROM Customer c, Invoice i, Employee e
	WHERE c.CustomerId = i.CustomerId
		AND c.CustomerId = e.ReportsTo
		AND (((NullIf(@DateFrom, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) >= @DateFrom)  
		AND ((NullIf(@DateTo, '') IS NULL)  OR CAST(i.InvoiceDate AS DATE) <= @DateTo))
		AND (((NullIf(@EmployeeFN, '') IS NULL)  OR CAST(e.FirstName AS NVARCHAR(50)) = @EmployeeFN)  
		AND ((NullIf(@EmployeeLN, '') IS NULL)  OR CAST(e.LastName AS NVARCHAR(50)) = @EmployeeLN))
		AND (((NullIf(@CustomerFN, '') IS NULL)  OR CAST(c.FirstName AS NVARCHAR(50)) = @CustomerFN)  
		AND ((NullIf(@CustomerLN, '') IS NULL)  OR CAST(c.LastName AS NVARCHAR(50)) = @CustomerLN))
COMMIT TRANSACTION
END
GO 1