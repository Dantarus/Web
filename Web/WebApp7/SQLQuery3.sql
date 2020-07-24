USE [D:\REPOZYTORIUM\WEB\WEBAPP7\WEBAPP7\APP_DATA\USERDATA.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[isLoginExist]
		@Email = N'mirek2@dt.pl',
		@Password = N'mirek3'

SELECT	@return_value as 'Return Value'

GO
