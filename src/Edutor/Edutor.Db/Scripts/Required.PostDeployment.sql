/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Inserta usuario adminsitrador:
INSERT INTO Users([Type],[Position],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','A','Antonio Feregrino Bolaños','FEBA911206HDFRLN09','antonio.feregrino@hotmail.es','Av. Juan de Dios Bátiz esq. Av. Miguel Othón de Mendizábal, Col. Lindavista. Del. Gustavo A. Madero. México, D. F. C. P. 07738.','5540481160','5540481160')
UPDATE Users SET [Password] =  CONVERT(varchar(max),HASHBYTES('SHA2_256',Curp),2) -- Contraseña de usuario
FROM Users

-- Inserta grupo por default
SET IDENTITY_INSERT Groups ON
INSERT INTO Groups([GroupId],[Name],[Subject],[FromDate]) VALUES(0,'Plantel','Grupo por default','01/01/2015')
SET IDENTITY_INSERT Groups OFF