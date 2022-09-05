ALTER PROC spInvoiceStatTable
AS
BEGIN
	BEGIN TRANSACTION
		
		DECLARE @ERRORCOUNT int = 0;

		IF OBJECT_ID('InvoiceStatistics') IS NOT NULL
			BEGIN

				PRINT ''
				PRINT 'TABLE EXIST'

				--!Error Check for DELETE ROWS
				BEGIN TRY
					DELETE FROM InvoiceStatistics;
					PRINT ''
					PRINT 'ALL ROWS DELETED'
				END TRY
				BEGIN CATCH
					SET @ERRORCOUNT = -2;
				END CATCH

				--!Error Check for INSERT ROWS
				BEGIN TRY
					INSERT INTO InvoiceStatistics (GenreId, TrackId, TotalTrackCharge, TimeCreated)
					SELECT t.GenreId, il.TrackId, il.UnitPrice*il.Quantity, i.InvoiceDate
					FROM InvoiceLine il, Track t, Invoice i
					WHERE il.TrackId = t.Trackid
					and il.invoiceid = i.invoiceid;
					PRINT ''
					PRINT 'ALL ROWS INSERTED'
				END TRY
				BEGIN CATCH
					SET @ERRORCOUNT = -3;
				END CATCH

			END
			ELSE
				BEGIN

				PRINT ''
				PRINT 'TABLE DOES NOT EXIST'

				--!Error Check for CREATE TABLE
				BEGIN TRY
					CREATE TABLE InvoiceStatistics (
								GenreId int, 
								TrackId int, 
								TotalTrackCharge numeric(10,2), 
								TimeCreated datetime);
					PRINT ''
					PRINT 'TABLE CREATED'
				END TRY
				BEGIN CATCH
					SET @ERRORCOUNT = -1;
				END CATCH

				--!Error Check for INSERT ROWS
				BEGIN TRY
					INSERT INTO InvoiceStatistics (GenreId, TrackId, TotalTrackCharge, TimeCreated)
					SELECT t.GenreId, il.TrackId, il.UnitPrice*il.Quantity, i.InvoiceDate
					FROM InvoiceLine il, Track t, Invoice i
					WHERE il.TrackId = t.Trackid
					and il.invoiceid = i.invoiceid;
					PRINT ''
					PRINT 'ALL ROWS INSERTED'
				END TRY
				BEGIN CATCH
					SET @ERRORCOUNT = -3;
				END CATCH

				END

		IF(@ERRORCOUNT = 0)
			BEGIN
				SELECT * FROM InvoiceStatistics
				COMMIT TRANSACTION
			END
		ELSE 
			BEGIN
				IF(@ERRORCOUNT = -1) RAISERROR('-1',16,1)
				IF(@ERRORCOUNT = -2) RAISERROR('-2',16,1)
				IF(@ERRORCOUNT = -3) RAISERROR('-3',16,1)
				ROLLBACK TRANSACTION
			END
END
GO 1