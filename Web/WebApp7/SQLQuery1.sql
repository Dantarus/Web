USE [D:\REPOZYTORIUM\WEB\WEBAPP7\WEBAPP7\APP_DATA\USERDATA.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[IsLogin]
		@Email = N'marian@dt.pl',
		@Password = N'marian1'

SELECT	@return_value as 'Return Value'

GO
