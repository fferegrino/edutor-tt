/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


DECLARE @SUid INT
INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone])
VALUES ('C', 'Antonio Feregrino', 'FEBA911206HDFRLN09', 'antonio.feregrino@hotmail.es', '13220', '5540841160', '58503735')

SET @SUid = SCOPE_IDENTITY()

INSERT INTO SchoolUsers([Position],[SchoolUserId])
VALUES ('P', @SUid)