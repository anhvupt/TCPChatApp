CREATE DATABASE DataChatBox
GO

USE DataChatBox;
GO

CREATE TABLE User_Account
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL
		DEFAULT 'ABC',
	Password NVARCHAR(100) NOT NULL
        DEFAULT 0,
)
 
CREATE PROC USP_Login
    @userName NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM dbo.User_Account
    WHERE name = @userName
          AND Password = @password;
END;
GO

CREATE PROC USP_AddAccount
    @userName NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.User_Account
    (
        name,
        Password
    )
    VALUES
    (   @userName, -- name - nvarchar(100)
        @password -- Password - nvarchar(100)
        )
END;
GO

EXEC dbo.USP_Login @userName = N'abc', -- nvarchar(100)
                   @password = N'1'  -- nvarchar(100)
go


INSERT INTO dbo.User_Account
(
    name,
    Password
)
VALUES
(   N'ben', -- name - nvarchar(100)
    N'1'  -- Password - nvarchar(100)
    )

	INSERT INTO dbo.User_Account
(
    name,
    Password
)

VALUES
(   N'trinh', -- name - nvarchar(100)
    N'1'  -- Password - nvarchar(100)
    )
	INSERT INTO dbo.User_Account
(
    name,
    Password
)
VALUES
(   N'vu', -- name - nvarchar(100)
    N'1'  -- Password - nvarchar(100)
    )

	INSERT INTO dbo.User_Account
(
    name,
    Password
)
VALUES
(   N'nhac', -- name - nvarchar(100)
    N'1'  -- Password - nvarchar(100)
    )

	INSERT INTO dbo.User_Account
(
    name,
    Password
)
VALUES
(   N'trung', -- name - nvarchar(100)
    N'1'  -- Password - nvarchar(100)
    )
