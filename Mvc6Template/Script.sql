SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Password] [nvarchar](50) NULL,
	[UserType] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[ModifiedOn] [date] NULL
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	-- Add the parameters for the stored procedure here
	@UserId int,
	@FirstName nvarchar(200),
	@LastName nvarchar(200),
	@Email nvarchar(100),
	@Phone nvarchar(20),
	@Password nvarchar(50),
	@UserType int
AS
BEGIN
	
	DECLARE @newId int
	INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Phone]
           ,[Password]
           ,[UserType]
           ,[IsActive]
           ,[CreatedOn]
           ,[ModifiedOn])
		VALUES(@FirstName,@LastName,@Email,@Phone,@Password,@UserType,1,GETDATE(),GETDATE())
	SET @newId = CAST(SCOPE_IDENTITY() AS INT);
	RETURN @newId
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AuthenticateUser]
	-- Add the parameters for the stored procedure here
	@Email nvarchar(200)
	,@Password nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [UserId]
      ,[FirstName]
      ,[LastName]
      ,[Email]
      ,[Phone]
      ,[UserType]
      ,[CreatedOn]
      ,[ModifiedOn]
  FROM [dbo].[Users] WHERE Email=LOWER( @Email) and @Password=@Password
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TOP (1000) [UserId]
      ,[FirstName]
      ,[LastName]
      ,[Email]
      ,[Phone]
      ,[Password]
      ,[UserType]
      ,[IsActive]
      ,[CreatedOn]
      ,[ModifiedOn]
  FROM [DemoDB].[dbo].[Users]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
	@UserId int,
	@FirstName nvarchar(200),
	@LastName nvarchar(200),
	@Phone nvarchar(20),
	@UserType int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	UPDATE [dbo].[Users]
	   SET [FirstName] = @FirstName
		  ,[LastName] = @LastName		  
		  ,[Phone] = @Phone		  
		  ,[UserType] = @UserType		  
		  ,[ModifiedOn] =GETDATE()
	 WHERE UserId=@UserId

END
GO
