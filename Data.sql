CREATE DATABASE BuyGear
GO

USE BuyGear
GO

CREATE TABLE Account
(
	username NVARCHAR(100) NOT NULL PRIMARY KEY,
	password NVARCHAR(100) NOT NULL ,
	type BIT DEFAULT 0
)
GO
CREATE TABLE Info
(
	username NVARCHAR(100) NOT NULL,
	name NVARCHAR(100) DEFAULT N'',
	numberphone VARCHAR(10) DEFAULT N'',
	email NVARCHAR(100) DEFAULT N'',
	address NVARCHAR(100) DEFAULT N'',
	sexual NVARCHAR(10) DEFAULT N'',
	birthday DATE

	FOREIGN KEY(username) REFERENCES dbo.Account (username)
)
GO

CREATE PROC Pro_Account @username NVARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE username = @username AND password = @password
END
GO

INSERT INTO dbo.Account
(
    username,
    password,
    type
)
VALUES
(   N'hoai', -- username - nvarchar(100)
    N'hoai', -- password - nvarchar(100)
    0 -- type - bit
    )
GO

UPDATE dbo.Account SET password = N'195901611197122657266637422542462262' WHERE username = N'hoai'
GO

CREATE PROC Pro_Username @username  NVARCHAR(100)
AS
BEGIN
	SELECT dbo.Account.username FROM dbo.Account WHERE username = @username
END
GO

SELECT * FROM dbo.Account
SELECT * FROM dbo.Info

CREATE PROC Pro_UpdatePass @password NVARCHAR(100), @username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Account SET password = @password WHERE username = @username
END
GO
EXEC Pro_UpdatePass @username = 'hoai', @password = '1949656839789924115999236219228216125116'


