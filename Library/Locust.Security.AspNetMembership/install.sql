/****** Object:  StoredProcedure [dbo].[usp1_Role_create]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Role_create] 
(
	@roleName	VARCHAR(30)
) AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [Role](Name) VALUES (@roleName)
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Role_delete]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Role_delete] 
(
	@roleName				VARCHAR(30),
	@throwOnPopulatedRole	BIT = 0
) AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM User_Role ur INNER JOIN [Role] r ON ur.RoleID = r.RoleID WHERE r.Name = @roleName)
	BEGIN
		IF @throwOnPopulatedRole = 1
			RAISERROR(N'نقش مشخص شده داراي تعدادي کاربر است و قابل حذف نيست', 10, 1)
		ELSE
			DELETE FROM [Role] WHERE Name = @roleName
	END
	ELSE
		DELETE FROM [Role] WHERE Name = @roleName
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Role_exists]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Role_exists]
(
	@roleName	VARCHAR(50),
	@Result		BIT	OUT
) AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM [Role] r WHERE r.Name = @roleName)
		SET @Result = 1
	ELSE
		SET @Result = 0
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Role_get_all]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Role_get_all]
(
	@roles	VARCHAR(4000)	OUT
) AS
BEGIN
	SET NOCOUNT ON;

    SET @roles = STUFF((SELECT ',' + Name FROM [Role] FOR XML PATH(''),TYPE).value('text()[1]','varchar(4000)'),1,1,N'')
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Role_get_users]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Role_get_users]
(
	@roleName	VARCHAR(50),
	@users		VARCHAR(4000)	OUT
) AS
BEGIN
	SET NOCOUNT ON;

    SET @users = STUFF((SELECT ',' + u.UserName FROM [Role] r INNER JOIN User_Role ur ON r.RoleID = ur.RoleID INNER JOIN [User] u ON ur.UserID = u.UserID WHERE r.Name = @roleName FOR XML PATH(''),TYPE).value('text()[1]','varchar(4000)'),1,1,N'')
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_User_get_roles]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_User_get_roles]
(
	@UserName	VARCHAR(50),
	@roles		VARCHAR(4000)	OUT
) AS
BEGIN
	SET NOCOUNT ON;

    SET @roles = STUFF((SELECT ',' + r.Name FROM [Role] r INNER JOIN User_Role ur ON r.RoleID = ur.RoleID INNER JOIN [User] u ON ur.UserID = u.UserID WHERE u.UserName = @UserName FOR XML PATH(''),TYPE).value('text()[1]','varchar(4000)'),1,1,N'')
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_User_is_in_role]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_User_is_in_role]
(
	@userName	VARCHAR(50),
	@roleName	VARCHAR(50),
	@Result		BIT	OUT
) AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM [User] u INNER JOIN User_Role ur ON u.UserID = ur.UserID INNER JOIN [Role] r ON ur.RoleID = r.RoleID WHERE u.UserName = @userName AND r.Name = @roleName)
		SET @Result = 1
	ELSE
		SET @Result = 0
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Users_add_to_roles]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Users_add_to_roles] 
(
	@UserNames	VARCHAR(4000) = '',
	@RoleNames	VARCHAR(4000) = ''
) AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @u	TABLE(UserName VARCHAR(50))
	DECLARE @r	TABLE(RoleName VARCHAR(30))
	DECLARE @ur	TABLE(UserName VARCHAR(50), RoleName VARCHAR(30))
	
	INSERT INTO @u
    EXEC dbo.usp0_CommaSeparatedList_to_table @UserNames
    
    INSERT INTO @r
    EXEC dbo.usp0_CommaSeparatedList_to_table @RoleNames
    
    INSERT INTO @ur(UserName, RoleName)
    SELECT u.UserName, r.RoleName
    FROM @u u, @r r
    
    INSERT INTO User_Role(UserID, RoleID)
    SELECT
		u.UserID, r.RoleID
    FROM			[User]	u
		INNER JOIN
		(
			SELECT ur1.UserName, ur1.RoleName
			FROM	@ur ur1
				LEFT JOIN
			(
				SELECT ur.UserRoleID, u1.UserName, r1.Name AS RoleName
				FROM			[User]		u1
					INNER JOIN	[User_Role]	ur	ON u1.UserID = ur.UserID
					INNER JOIN	[Role]		r1	ON ur.RoleID = r1.RoleID
			) ur2	ON ur1.UserName = ur2.UserName AND ur1.RoleName = ur2.RoleName
			WHERE ur2.UserRoleID IS NULL
		) nr	ON u.UserName = nr.UserName
		INNER JOIN	[Role]	r ON r.Name = nr.RoleName
END
GO
/****** Object:  StoredProcedure [dbo].[usp1_Users_remove_from_roles]    Script Date: 6/12/2018 12:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		omrani
-- Create date: 2012/08/29
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp1_Users_remove_from_roles] 
(
	@UserNames	VARCHAR(4000) = '',
	@RoleNames	VARCHAR(4000) = ''
) AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @u	TABLE(UserName VARCHAR(50))
	DECLARE @r	TABLE(RoleName VARCHAR(30))
	DECLARE @ur	TABLE(UserName VARCHAR(50), RoleName VARCHAR(30))
	
	INSERT INTO @u
    EXEC dbo.usp0_CommaSeparatedList_to_table @UserNames
    
    INSERT INTO @r
    EXEC dbo.usp0_CommaSeparatedList_to_table @RoleNames
    
    INSERT INTO @ur(UserName, RoleName)
    SELECT u.UserName, r.RoleName
    FROM @u u, @r r
    
    DELETE FROM User_Role
    WHERE UserRoleID IN
	(
		SELECT ur2.UserRoleID
		FROM	@ur ur1
			INNER JOIN
		(
			SELECT ur.UserRoleID, u1.UserName, r1.Name AS RoleName
			FROM			[User]		u1
				INNER JOIN	[User_Role]	ur	ON u1.UserID = ur.UserID
				INNER JOIN	[Role]		r1	ON ur.RoleID = r1.RoleID
		) ur2	ON ur1.UserName = ur2.UserName AND ur1.RoleName = ur2.RoleName
	)
END
GO
