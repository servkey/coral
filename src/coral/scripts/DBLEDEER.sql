USE [DBLEDEER]
GO
/****** Object:  Table [dbo].[TblActions]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblActions](
	[idAction] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TblActions1] PRIMARY KEY CLUSTERED 
(
	[idAction] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblActors]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblActors](
	[idActor] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](40) NOT NULL,
 CONSTRAINT [PK_TblActors] PRIMARY KEY CLUSTERED 
(
	[idActor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblRolesActancial]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblRolesActancial](
	[idRoleAct] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TblRolesActancial] PRIMARY KEY CLUSTERED 
(
	[idRoleAct] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblRoles]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblRoles](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblRoles] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProcessSentences]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblProcessSentences](
	[idProcess] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblProcessSentences] PRIMARY KEY CLUSTERED 
(
	[idProcess] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblObjects]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblObjects](
	[idObj] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](40) NOT NULL,
	[AtrVal] [varchar](40) NOT NULL,
 CONSTRAINT [PK_TblObjects] PRIMARY KEY CLUSTERED 
(
	[idObj] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblArenas](
	[idArena] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TblArenas] PRIMARY KEY CLUSTERED 
(
	[idArena] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblTypesSentences]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblTypesSentences](
	[IdType] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblTypesSentences] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[updateRoleActancial]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar role actancial,,>Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateRoleActancial](
	@IdRoleAct int, 
	@AtrNameRoleActUpdate varchar(50), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblRolesActancial WHERE
		IdRoleAct = @IdRoleAct
	--Si existe la acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblRolesActancial
		SET
			AtrName = @AtrNameRoleActUpdate
		WHERE IdRoleAct=@IdRoleAct
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateRole]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar Arena,,>Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateRole](
	@IdRole int, 
	@AtrNameRoleUpdate varchar(50), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblRoles WHERE
		IdRole = @IdRole
	--Si existe la acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblRoles
		SET
			AtrName = @AtrNameRoleUpdate
		WHERE IdRole=@IdRole
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateObject]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar objecto,,>Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateObject](
	@IdObj int, 
	@AtrNameObjUpdate varchar(40), 
	@AtrNameValUpdate varchar(40), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblObjects WHERE
		IdObj = @IdObj
	--Si existe el objeto acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblObjects
		SET
			AtrName = @AtrNameObjUpdate,
			AtrVal = @AtrNameValUpdate
		WHERE IdObj=@IdObj
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateArena]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar Arena,,>Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateArena](
	@IdArena int, 
	@AtrNameArenaUpdate varchar(100), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblArenas WHERE
		IdArena = @IdArena
	--Si existe la acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblArenas
		SET
			AtrName = @AtrNameArenaUpdate
		WHERE IdArena=@IdArena
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateActor]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar Actor,,>Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateActor](
	@IdActor int, 
	@AtrNameActorUpdate varchar(40), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblActors WHERE
		IdActor = @IdActor
	--Si existe la acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblActors
		SET
			AtrName = @AtrNameActorUpdate
		WHERE IdActor=@IdActor
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateAction]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar Action,,>Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateAction](
	@IdAction int, 
	@AtrNameActionUpdate varchar(100), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblActions WHERE
		IdAction = @IdAction
	--Si existe la acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblActions
		SET
			AtrName = @AtrNameActionUpdate
		WHERE IdAction=@IdAction
	END
END
GO
/****** Object:  Table [dbo].[TblArena_TblRolesActancial]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblRolesActancial](
	[IdArena] [int] NOT NULL,
	[IdRoleAct] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblRoles]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblRoles](
	[IdArena] [int] NOT NULL,
	[IdRole] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblObjects]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblObjects](
	[IdArena] [int] NOT NULL,
	[IdObj] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblActors]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblActors](
	[idArena] [int] NOT NULL,
	[idActor] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblActor_TblRoleActancial]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblActor_TblRoleActancial](
	[idArena] [int] NOT NULL,
	[idActor] [int] NOT NULL,
	[idRolAct] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblActor_TblRole]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblActor_TblRole](
	[idArena] [int] NOT NULL,
	[idActor] [int] NOT NULL,
	[idRole] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblActions]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblActions](
	[idArena] [int] NOT NULL,
	[idAction] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblArena_TblAction_TblRoleActancial]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArena_TblAction_TblRoleActancial](
	[idArena] [int] NOT NULL,
	[idAction] [int] NOT NULL,
	[idRoleAct] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblScenarios]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblScenarios](
	[idScenario] [int] IDENTITY(1,1) NOT NULL,
	[AtrName] [varchar](100) NOT NULL,
	[AtrDescription] [text] NULL,
	[idAction] [int] NOT NULL,
	[idArena] [int] NOT NULL,
 CONSTRAINT [PK_TblScenarios] PRIMARY KEY CLUSTERED 
(
	[idScenario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblActions_TblRolesActancial]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblActions_TblRolesActancial](
	[idAction] [int] NOT NULL,
	[idRoleAct] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblActions_TblRoles]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblActions_TblRoles](
	[idAction] [int] NOT NULL,
	[idRole] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblActions_TblActors]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblActions_TblActors](
	[idAction] [int] NOT NULL,
	[idActor] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetTypeSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar tipos,,>
-- Regresa más de 0 si hay elementos en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetTypeSentence] 
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar tipos

	--mostrar arenas
	SELECT IdType, AtrName FROM TblTypesSentences
END
GO
/****** Object:  StoredProcedure [dbo].[GetRolesActancial]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar roles actanciales,,>
-- Regresa más de 0 si hay elementos en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetRolesActancial]
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles actanciales

	--mostrar Roles actanciales
	SELECT IdRoleAct, AtrName FROM TblRolesActancial
END
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar roles,,>
-- Regresa más de 0 si hay elementos en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetRoles] 
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles

    --mostrar Roles
	SELECT IdRole,AtrName FROM TblRoles

END
GO
/****** Object:  StoredProcedure [dbo].[GetProcessSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar tipos,,>
-- Regresa más de 0 si hay elementos en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetProcessSentence]
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar procesos del escenario
			--mostrar arenas

	SELECT IdProcess,AtrName FROM TblProcessSentences
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetObjects]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar objetos,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetObjects] 
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar objetos

	SELECT IdObj, AtrName, AtrVal FROM TblObjects
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenas]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenar,> 
--Regresa mas de 0 si hay elementos
-- =============================================

CREATE PROCEDURE [dbo].[GetArenas]
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar arenas


	--mostrar arenas
	SELECT IdArena,AtrName FROM TblArenas
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdObject]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<GetIdAction,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdObject] (
		@AtrName varchar(40)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdObject INT;	
	DECLARE @Existe INT;	

	SET @IdObject = -1;
	SET @Existe = -1;

	--Get Id Object de un actor
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblObjects WHERE
			TblObjects.AtrName = @AtrName
	IF @Existe > 0 
	BEGIN
	  	--insertar usuario			
		SELECT @IdObject=IdObj FROM TblObjects WHERE AtrName=@AtrName;
	END	
	RETURN @IdObject
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdActor]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdActor] (
		@AtrName varchar(40)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdActor INT;	
	DECLARE @Existe INT;	

	SET @IdActor = -1;
	SET @Existe = -1;

	--Get Id Actor de un actor
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblActors WHERE
			TblActors.AtrName = @AtrName
	IF @Existe > 0 --que el usuario  exista 
	BEGIN
	  	--insertar usuario			
		SELECT @IdActor=IdActor FROM TblActors WHERE AtrName=@AtrName;
	END	
	RETURN @IdActor
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdRoleActancial]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<obtener id de rol actancial,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdRoleActancial] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdRoleAct INT;	
	DECLARE @Existe INT;	

	SET @IdRoleAct = -1;
	SET @Existe = -1;

	--Get Id Role 
		
	SELECT @Existe=COUNT(*) FROM TblRolesActancial WHERE
			TblRolesActancial.AtrName = @AtrName
	IF @Existe > 0 --que el usuario  exista 
	BEGIN
		--obtener ID
		SELECT @IdRoleAct = IdRoleAct FROM TblRolesActancial WHERE AtrName=@AtrName;
	END	
	RETURN @IdRoleAct
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdRole1]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<obtener id de rol,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdRole1] (
		@AtrName varchar(40)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdRole INT;	
	DECLARE @Existe INT;	

	
	SET @Existe = -1;

	--Get Id Role 
		
	SELECT @Existe=COUNT(*) FROM TblRoles WHERE
			TblRoles.AtrName = @AtrName
	IF @Existe > 0 --que el usuario  exista 
	BEGIN
		--obtener ID
		SELECT IdRole FROM TblRoles WHERE AtrName=@AtrName;
	END	
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdRole]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<obtener id de rol,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdRole] (
		@AtrName varchar(40)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdRole INT;	
	DECLARE @Existe INT;	

	SET @IdRole = -1;
	SET @Existe = -1;

	--Get Id Role 
		
	SELECT @Existe=COUNT(*) FROM TblRoles WHERE
			TblRoles.AtrName = @AtrName
	IF @Existe > 0 --que el usuario  exista 
	BEGIN
		--obtener ID
		SELECT @IdRole = IdRole FROM TblRoles WHERE AtrName=@AtrName;
	END	
	RETURN @IdRole
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdArena1]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdArena1] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdArena INT;	
	DECLARE @Existe INT;	

	
	SET @Existe = -1;

	--Get Id Actor de un actor
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblArenas WHERE
			TblArenas.AtrName = @AtrName
	IF @Existe > 0 --que la arena exista 
	BEGIN
	  	--insertar usuario			
		SELECT IdArena FROM TblArenas WHERE AtrName=@AtrName;
	END	
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdArena]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdArena] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdArena INT;	
	DECLARE @Existe INT;	

	SET @IdArena = -1;
	SET @Existe = -1;

	--Get Id Actor de un actor
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblArenas WHERE
			TblArenas.AtrName = @AtrName
	IF @Existe > 0 --que la arena exista 
	BEGIN
	  	--insertar usuario			
		SELECT @IdArena=IdArena FROM TblArenas WHERE AtrName=@AtrName;
	END	
	RETURN @IdArena
END
GO
/****** Object:  StoredProcedure [dbo].[GetArena]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenar,> 
--Regresa mas de 0 si hay elementos
-- =============================================

CREATE PROCEDURE [dbo].[GetArena](
	@IdArena int
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar arena
	SELECT IdArena,AtrName FROM TblArenas
		WHERE IdArena=@IdArena
END
GO
/****** Object:  StoredProcedure [dbo].[GetActors]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar actores,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetActors]
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar actores
	--mostrar arenas
	SELECT IdActor, AtrName FROM TblActors
END
GO
/****** Object:  StoredProcedure [dbo].[GetActions]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar acciones,,>
-- Regresa más de 0 si hay elementos en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetActions] 
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar acciones

	--mostrar acciones
	SELECT IdAction, AtrName FROM TblActions
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdAction]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<GetIdAction,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdAction] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdAction INT;	
	DECLARE @Existe INT;	

	SET @IdAction = -1;
	SET @Existe = -1;

	--Get Id Actor de un actor
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblActions WHERE
			TblActions.AtrName = @AtrName
	IF @Existe > 0 --que kla arena exista 
	BEGIN
	  	--insertar usuario			
		SELECT @IdAction=IdAction FROM TblActions WHERE AtrName=@AtrName;
	END	
	RETURN @IdAction
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdScenarioType]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar tipo de escenario,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdScenarioType] (
		@IdType int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar tipo de escenario

	DECLARE @Existe1 int;
	
	SELECT @Existe1= COUNT(*) FROM TblTypesSentences WHERE  IdType=@IdType;
	
	SELECT @Existe = -1;
	
	IF @Existe1 <> 0 --que el tipo exista 
	BEGIN
			--eliminar actor
			DELETE FROM TblTypesSentences WHERE  IdType=@IdType;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArena]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar arena de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArena] (
		@IdArena int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar arena
	DECLARE @Existe1 INT
	
	SELECT @Existe1 = COUNT(*) FROM TblArenas WHERE  IdArena=@IdArena;;
	SELECT  @Existe = -1

	IF @Existe1 <> 0 --que el actor exista 
	BEGIN
			--eliminar actor
			DELETE FROM TblArenas WHERE  IdArena=@IdArena;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdActor]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdActor] (
		@IdActor int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar actor
	DECLARE @Existe1 int
	
	SELECT @Existe1 = COUNT(*) FROM TblActors WHERE  IdActor=@IdActor;
	SELECT  @Existe = -1 
	IF @Existe1 <> 0 --que el actor exista
	BEGIN
			--eliminar actor
			DELETE FROM TblActors WHERE  IdActor=@IdActor;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdScenarioProcess]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar tipo de escenario,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdScenarioProcess] (
		@IdProcess int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar proceso de escenario
	--initialize
	--finalize

	DECLARE @Existe1 INT;
				
	SELECT @Existe1= COUNT(*) FROM TblProcessSentences WHERE  IdProcess=@IdProcess;
	
	SELECT @Existe = -1;
	
	IF @Existe1 <> 0 --que el tipo exista 
	BEGIN
			--eliminar actor
			DELETE FROM TblProcessSentences WHERE  IdProcess=@IdProcess;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdRoleActancial] (
		@IdRoleAct int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar rol actancial

	
	DECLARE @Existe1 INT
	
	SELECT @Existe1=COUNT(*) FROM TblRolesActancial WHERE  IdRoleAct=@IdRoleAct;
	SELECT @Existe = -1;
	IF @Existe1 <> 0 --que el rol actancial exista 
	BEGIN
			--eliminar rol actancial
			DELETE FROM TblRolesActancial WHERE  IdRoleAct=@IdRoleAct;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdRole] (
		@IdRole int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar rol

	DECLARE @Existe1 int;
	SELECT @Existe1=COUNT(*) FROM TblRoles WHERE  IdRole=@IdRole; 
		
	SELECT @Existe = -1;
	
	IF @Existe1 <> 0 --que el rol exista 
	BEGIN
			--eliminar rol
			DELETE from TblRoles WHERE  IdRole=@IdRole;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdObject]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdObject] (
		@IdObj int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar objeto

	SELECT @Existe = -1;
	
	IF (SELECT COUNT(*) FROM TblObjects WHERE IdObj=@IdObj) > 0 --que el objeto exista 
	BEGIN
			--eliminar actor
			DELETE from TblObjects WHERE  IdObj=@IdObj;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddScenarioProcess]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddProcess,,> Regresa 0 si se inserta
-- Sino ya existe la funcionalidad
-- =============================================

CREATE PROCEDURE [dbo].[AddScenarioProcess] (
		@AtrNameProcess varchar(50),
		@Existe int output
)

AS
BEGIN
	SET NOCOUNT ON;
	--Agregar porceso ha escenario 
	--Por default :
	-- Initalize
	-- Finalize

	SELECT  @Existe = -1 --No ha sido insertado

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblProcessSentences WHERE
			TblProcessSentences.AtrName = @AtrNameProcess

	--Si Existe1 es igual 0 es insertado 
			
	IF @Existe1 = 0 
	BEGIN
			--insertar proceso a escenario		
			INSERT INTO TblProcessSentences VALUES (@AtrNameProcess);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddRolActancial,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddRoleActancial] (
		@AtrName varchar(100),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar un nuevo rol actancial
	SELECT @Existe=COUNT(*) FROM TblRolesActancial WHERE
			TblRolesActancial.AtrName = @AtrName
	IF @Existe = 0 --que el rol actancial no exista 
	BEGIN
			--insertar rol actancial
			INSERT INTO TblRolesActancial VALUES (@AtrName);
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddRol,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddRole] (
		@AtrName varchar(50),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar un nuevo rol
	SELECT @Existe=COUNT(*) FROM TblRoles WHERE
			TblRoles.AtrName = @AtrName
	IF @Existe = 0 --que el rol no exista 
	BEGIN
			--insertar usuario			
			INSERT INTO TblRoles VALUES (@AtrName);
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddObject]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddObject] (
		@AtrName varchar(40),
		@AtrVal varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar un nuevo objeto
	SELECT @Existe = COUNT(*) FROM TblObjects WHERE TblObjects.AtrName = @AtrName
	IF (@Existe) = 0 --que el usuario no exista 
	BEGIN
			--insertar usuario			
			INSERT INTO TblObjects VALUES (@AtrName,@AtrVal);
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArena]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActor,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddArena] (
		@AtrName varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar nueva arena
	SELECT @Existe=COUNT(*) FROM TblArenas WHERE
			TblArenas.AtrName = @AtrName
	IF @Existe = 0 --que el usuario no exista 
	BEGIN
			--insertar usuario			
			INSERT INTO TblArenas VALUES (@AtrName);
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddActor]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddActor] (
		@AtrName varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar un nuevo actor
	SELECT @Existe=COUNT(*) FROM TblActors WHERE
			TblActors.AtrName = @AtrName
	IF @Existe = 0 --que el usuario no exista 
	BEGIN
			--insertar usuario			
			INSERT INTO TblActors VALUES (@AtrName);
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddAction]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActor,,> Regresa 0 si se inserta
-- Sino ya existe la funcionalidad
-- =============================================

CREATE PROCEDURE [dbo].[AddAction] (
		@AtrName varchar(100),
		@Existe int output
)

AS
BEGIN
	SET NOCOUNT ON;
	--Agregar acción o funcionalidad

	SELECT  @Existe = -1 --No ha sido insertado

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblActions WHERE
			TblActions.AtrName = @AtrName

	--Si Existe1 es igual 0 es insertado 
			
	IF @Existe1 = 0 
	BEGIN
			--insertar usuario			
			INSERT INTO TblActions VALUES (@AtrName);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdAction]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar acción ,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdAction] (
		@IdAction int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar acción
	DECLARE @Existe1 int 
	
	SELECT @Existe1= COUNT(*) FROM TblActions WHERE IdAction = @IdAction;
	SELECT @Existe = -1
	IF @Existe1 <> 0 --que la acción exista 
	BEGIN
			--eliminar actor
			DELETE from TblActions WHERE  IdAction=@IdAction;
			SELECT @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddScenarioType]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddType,,> Regresa 0 si se inserta
-- Sino ya existe la funcionalidad
-- =============================================

CREATE PROCEDURE [dbo].[AddScenarioType] (
		@AtrNameType varchar(50),
		@Existe int output
)

AS
BEGIN
	SET NOCOUNT ON;
	--Agregar tipo de sentencia ha escenario 
	--Por default :
	-- Precondition
	-- Poscondition

	SELECT  @Existe = -1 --No ha sido insertado

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblTypesSentences WHERE
			TblTypesSentences.AtrName = @AtrNameType

	--Si Existe1 es igual 0 es insertado 
			
	IF @Existe1 = 0 
	BEGIN
			--insertar tipo a escenario		
			INSERT INTO TblTypesSentences VALUES (@AtrNameType);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaAction]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar acción de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaAction] (
		@AtrNameArena varchar (100),
		@AtrNameAction varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar acción de la arena
	DECLARE @IdAction int;
	EXEC @IdAction = GetIdAction @AtrNameAction
	

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	--SELECT IdArena = @IdArena

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblActions WHERE
			TblArena_TblActions.IdArena = @IdArena AND TblArena_TblActions.IdAction = @IdAction
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 <>  0 AND @IdAction <> -1 AND @IdArena <> -1 --que la acción y arena no exista 
	BEGIN
			--insertar usuario			
			DELETE from TblArena_TblActions WHERE  IdArena=@IdArena AND IdAction=@IdAction;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelArena]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar arena de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArena] (
		@AtrName varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar arena

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrName
		
	SELECT @Existe = -1;
	
	IF @IdArena <> -1 --que el actor exista 
	BEGIN
			--eliminar actor
			DELETE from TblArenas WHERE  IdArena=@IdArena;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelActor]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelActor] (
		@AtrName varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar actor

	DECLARE @IdActor int;
	EXEC @IdActor = GetIdActor @AtrName
	--SELECT IdActor = @IdActor
	
	SELECT @Existe = -1;
	
	IF @IdActor <> -1 --que el actor exista 
	BEGIN
			--eliminar actor
			DELETE from TblActors WHERE  IdActor=@IdActor;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelActionRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<eliminar RolActancial de una
-- funcionalidad,,> Regresa 0 si se inserta
-- Una acción sólo puede tener un rol actancial
-- =============================================
CREATE PROCEDURE [dbo].[DelActionRoleActancial] (
		@AtrNameAction varchar(100),		
		@AtrNameRoleAct varchar(100),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT @Existe=-1
	--Agregar un rol actancial a una funcionalidad
	DECLARE @IdAction int;
	DECLARE @IdRoleAct int;

	EXEC @IdAction = GetIdAction @AtrNameAction
	EXEC @IdRoleAct = GetIdRoleActancial @AtrNameRoleAct

	IF @IdAction <> -1 AND @IdRoleAct <> -1
	BEGIN --Asignar rol actancial a una funcionalidad
		DELETE FROM TblActions_TblRolesActancial WHERE IdAction= @IdAction AND IdRoleAct = @IdRoleAct;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelAction]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar acción ,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelAction] (
		@AtrName varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar acción

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdAction @AtrName
	
	
	SELECT @Existe = -1;
	
	IF @IdAction <> -1 --que la acción exista 
	BEGIN
			--eliminar actor
			DELETE from TblActions WHERE  IdAction=@IdAction;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaActor]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaActor] (
		@AtrNameArena varchar (100),
		@AtrNameActor varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar actor a arena

	DECLARE @IdActor int;
	EXEC @IdActor = GetIdActor @AtrNameActor
	--SELECT IdActor = @IdActor

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	--SELECT IdArena = @IdArena

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblActors WHERE
			TblArena_TblActors.IdArena = @IdArena AND TblArena_TblActors.IdActor = @IdActor
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 <>  0 AND @IdActor <> -1 AND @IdArena <> -1 --que el actor y arena no exista 
	BEGIN
			--insertar usuario			
			DELETE from TblArena_TblActors WHERE  IdArena=@IdArena AND IdActor=@IdActor;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar acción de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaRoleActancial] (
		@AtrNameArena varchar (100),
		@AtrNameRoleAct varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar role actancial de la arena
	DECLARE @IdRoleAct int;
	EXEC @IdRoleAct = GetIdRoleActancial @AtrNameRoleAct
	

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	--SELECT IdArena = @IdArena

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblRolesActancial WHERE
			TblArena_TblRolesActancial.IdArena = @IdArena AND TblArena_TblRolesActancial.IdRoleAct = @IdRoleAct
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 <>  0 AND @IdRoleAct <> -1 AND @IdArena <> -1 --que la acción y arena no exista 
	BEGIN
			--eliminar role actancial de la arena
			DELETE from TblArena_TblRolesActancial WHERE  IdArena=@IdArena AND IdRoleAct=@IdRoleAct;
			
			DELETE from TblArena_TblAction_TblRoleActancial WHERE  
				TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
				TblArena_TblAction_TblRoleActancial.IdRoleAct = @IdRoleAct --AND
		

			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar rol de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaRole] (
		@AtrNameArena varchar (100),
		@AtrNameRole varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar rol de la arena
	DECLARE @IdRole int;
	EXEC @IdRole = GetIdRole @AtrNameRole
	
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblRoles WHERE
			TblArena_TblRoles.IdArena = @IdArena AND TblArena_TblRoles.IdRole = @IdRole
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 <>  0 AND @IdRole <> -1 AND @IdArena <> -1 --que la acción y arena no exista 
	BEGIN
			--eliminar role de la arena		
			DELETE from TblArena_TblRoles WHERE  IdArena=@IdArena AND IdRole=@IdRole;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaObject]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<DelObjectArena,,> Regresa 0 si se elimina
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaObject] (
		@AtrNameArena varchar (100),
		@AtrNameObject varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar un object de una arena

	SELECT  @Existe = -1 --No ha sido eliminado
	--eliminar objeto de la arena

	DECLARE @IdObj int;
	EXEC @IdObj = GetIdObject @AtrNameObject

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	--Que existe la arena y q el objeto  exista
	IF @IdArena <> -1  AND @IdObj <> -1
	BEGIN
			--BORRAR objeto
			DELETE FROM TblArena_TblObjects WHERE
				IdArena = @IdArena AND IdObj = @IdObj;
			SELECT  @Existe = 0
		
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaActor]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActor,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddArenaActor] (
		@AtrNameArena varchar (100),
		@AtrNameActor varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar actor a arena

	DECLARE @IdActor int;
	EXEC @IdActor = GetIdActor @AtrNameActor
	--SELECT IdActor = @IdActor

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	--SELECT IdArena = @IdArena

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblActors WHERE
			TblArena_TblActors.IdArena = @IdArena AND TblArena_TblActors.IdActor = @IdActor
	--Si Existe1 es igual 0 es insertado ya que el actor no se encuentra en la arena

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 = 0 AND @IdActor <> -1 AND @IdArena <> -1 --que el usuario no exista 
	BEGIN
			--insertar usuario			
			INSERT INTO TblArena_TblActors VALUES (@IdArena,@IdActor);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaAction]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActionArena,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddArenaAction] (
		@AtrNameArena varchar (100),
		@AtrNameAction varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar actor a arena

	SELECT  @Existe = -1 --No ha sido insertado
	--Insertar Acción sino existe

	--EXEC AddAction @AtrNameAction,0
		
	DECLARE @IdAction int;
	EXEC @IdAction = GetIdAction @AtrNameAction

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblActions WHERE
			TblArena_TblActions.IdArena = @IdArena AND TblArena_TblActions.IdAction = @IdAction
	--Si Existe1 es igual 0 es insertado ya que el actor no se encuentra en la arena

			
	IF @Existe1 = 0 AND @IdAction <> -1 AND @IdArena <> -1 --que el usuario no exista 
	BEGIN
			--insertar acción en la arena
			INSERT INTO TblArena_TblActions VALUES (@IdArena,@IdAction);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddActionRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddRolActancial a funcionalidad,,> Regresa 0 si se inserta
-- Una acción sólo puede tener un rol actancial
-- =============================================
CREATE PROCEDURE [dbo].[AddActionRoleActancial] (
		@AtrNameAction varchar(100),		
		@AtrNameRoleAct varchar(100),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT @Existe=-1
	--Agregar un rol actancial a una funcionalidad
	DECLARE @IdAction int;
	DECLARE @IdRoleAct int;

	EXEC @IdAction = GetIdAction @AtrNameAction
	EXEC @IdRoleAct = GetIdRoleActancial @AtrNameRoleAct

	IF @IdAction <> -1 AND @IdRoleAct <> -1
		
	BEGIN --Asignar rol actancial a una funcionalidad
		SELECT @Existe=COUNT(*) FROM TblActions_TblRolesActancial
		WHERE
			TblActions_TblRolesActancial.IdAction = @IdAction AND
			TblActions_TblRolesActancial.IdRoleAct = @IdRoleAct

		IF @Existe = 0 --que el rol actancial no exista en la funcionalidad
		BEGIN
				INSERT INTO TblActions_TblRolesActancial VALUES (@IdAction,@IdRoleAct);
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActionArena,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddArenaRoleActancial] (
		@AtrNameArena varchar (100),
		@AtrNameRoleAct varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar actor a arena

	SELECT  @Existe = -1 --No ha sido insertado
	--Insertar Acción sino existe

	--EXEC AddAction @AtrNameAction,0
		
	DECLARE @IdRoleAct int;
	EXEC @IdRoleAct = GetIdRoleActancial @AtrNameRoleAct

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblRolesActancial WHERE
			TblArena_TblRolesActancial.IdArena = @IdArena AND TblArena_TblRolesActancial.IdRoleAct = @IdRoleAct
	--Si Existe1 es igual 0 es insertado ya que el actor no se encuentra en la arena

			
	IF @Existe1 = 0 AND @IdRoleAct <> -1 AND @IdArena <> -1 --que el usuario no exista 
	BEGIN
			--insertar acción en la arena
			INSERT INTO TblArena_TblRolesActancial VALUES (@IdArena,@IdRoleAct);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddRolArena,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddArenaRole] (
		@AtrNameArena varchar (100),
		@AtrNameRole varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar rol a arena

	EXEC AddRole @AtrNameRole,0

	DECLARE @IdRole int;
	EXEC @IdRole = GetIdRole @AtrNameRole

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena


	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblRoles WHERE
			TblArena_TblRoles.IdArena = @IdArena AND TblArena_TblRoles.IdRole = @IdRole
	--Si Existe1 es igual 0 es insertado ya que el actor no se encuentra en la arena

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 = 0 AND @IdRole <> -1 AND @IdArena <> -1 --que el usuario no exista 
	BEGIN
			--insertar usuario			
			INSERT INTO TblArena_TblRoles VALUES (@IdArena,@IdRole);
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaObject]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActionArena,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddArenaObject] (
		@AtrNameArena varchar (100),
		@AtrNameObject varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar arena un object

	SELECT  @Existe = -1 --No ha sido insertado
	--Insertar objeto a arena

	DECLARE @IdObj int;
	EXEC @IdObj = GetIdObject @AtrNameObject
	
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	
	--Que existe la arena y q el objeto que no exista
	IF @IdArena <> -1  AND @IdObj <> -1 AND 
		(SELECT COUNT(*) FROM TblArena_TblObjects WHERE IdArena=@IdArena AND IdObj=@IdObj) = 0
	BEGIN
			--insertar objeto
			INSERT INTO TblArena_TblObjects VALUES (@IdArena, @IdObj);
			SELECT  @Existe = 0
		
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar rol de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArenaRole] (
		@IdArena int,
		@IdRole int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar rol de la arena
	
	DECLARE @Existe1 int;
	SET @Existe1 = 0;
	SELECT @Existe1=COUNT(*) FROM TblArena_TblRoles WHERE
			TblArena_TblRoles.IdArena = @IdArena AND TblArena_TblRoles.IdRole = @IdRole
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 <>  0 
	BEGIN
			--eliminar role de la arena		
			DELETE from TblArena_TblRoles WHERE  IdArena=@IdArena AND IdRole=@IdRole;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaObject]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<DelObjectArena,,> Regresa 0 si se elimina
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArenaObject] (
		@IdArena int,
		@IdObj int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar un object de una arena

	SELECT  @Existe = -1 --No ha sido eliminado
	--eliminar objeto de la arena

	DECLARE @Existe1 int;
	SELECT @Existe1 = COUNT(*) FROM TblArena_TblObjects 
	WHERE IdArena=@IdArena AND IdObj=@IdObj

	--Que existe la arena y q el objeto  exista
	IF @Existe1 <> 0
	BEGIN
			--BORRAR objeto
			DELETE FROM TblArena_TblObjects WHERE
				IdArena = @IdArena AND IdObj = @IdObj;
			SELECT  @Existe = 0
		
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaActorRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArenaActorRole] (
		@IdArena int,
		--@AtrNameRole varchar(50),
		@IdActor int,
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	--Elimnar rol a un actor

	
	DECLARE @Existe1 int;
	SET @Existe1 = -1
	SELECT  @Existe = -1 --No ha sido insertado
	SELECT @Existe1=COUNT(*) FROM TblArena_TblActor_TblRole WHERE
			TblArena_TblActor_TblRole.IdArena = @IdArena AND
			TblArena_TblActor_TblRole.IdActor = @IdActor --AND
			--TblArena_TblActor_TblRole.IdRole = @IdRole

		--Si Existe1 es diferente a 0 es eliminado 
	
	IF @Existe1 <>  0 
	BEGIN
			--eliminar usuario			
			DELETE from TblArena_TblActor_TblRole WHERE  
				TblArena_TblActor_TblRole.IdArena = @IdArena AND
				TblArena_TblActor_TblRole.IdActor = @IdActor --AND
			--	TblArena_TblActor_TblRole.IdRole = @IdRole
			SELECT  @Existe = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaActor]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArenaActor] (
		@IdArena int,
		@IdActor int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar actor a arena

	DECLARE @Existe1 int;
		
	SELECT @Existe1=COUNT(*) FROM TblArena_TblActors WHERE
			TblArena_TblActors.IdArena = @IdArena AND TblArena_TblActors.IdActor = @IdActor
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1 --No ha sido insertado
			
	IF @Existe1 <>  0 --que el actor y arena no exista 
	BEGIN
			--insertar usuario			
			DELETE from TblArena_TblActors WHERE  IdArena=@IdArena AND IdActor=@IdActor;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaActionScenario]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddRolArena,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[DelIdArenaActionScenario] (
		@IdArena int,
		@IdAction int,
		@IdScenario int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar scenario a una funcionalidad definida en
	--una arena

	DECLARE @Existe1 int
	SELECT @Existe1=COUNT(*) FROM TblScenarios WHERE IdScenario = @IdScenario;

	SELECT @Existe=-1
	IF @Existe1 <> 0
	BEGIN
			--eliminar rol actancial a una funcionalidad
			DELETE FROM TblScenarios WHERE IdScenario = @IdScenario;
			SELECT  @Existe = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaActionRoleAct]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar rol actancial de una 
-- funcionalidad en la arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArenaActionRoleAct] (
		@IdArena int,
		@IdAction int,
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	--Elimnar rol actancial a una acción a un actor
	
	DECLARE @Existe1 INT
	SELECT @Existe1=COUNT(*) FROM TblArena_TblAction_TblRoleActancial WHERE
			TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
			TblArena_TblAction_TblRoleActancial.IdAction = @IdAction --AND
			--TblArena_TblActor_TblRole.IdRole = @IdRole

		--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1
	IF @Existe1 <>  0 
	BEGIN
			--eliminar rol			
			DELETE FROM TblArena_TblAction_TblRoleActancial WHERE  
				TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
				TblArena_TblAction_TblRoleActancial.IdAction = @IdAction --AND
			--	TblArena_TblActor_TblRole.IdRole = @IdRole
			SELECT  @Existe = 0
	END	
	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdArenaAction]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar acción de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdArenaAction] (
		@IdArena int,
		@IdAction int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Eliminar acción de la arena
		--SELECT IdArena = @IdArena
	
	DECLARE @Existe1 INT

	SELECT @Existe1=COUNT(*) FROM TblArena_TblActions WHERE
			TblArena_TblActions.IdArena = @IdArena AND TblArena_TblActions.IdAction = @IdAction
	--Si Existe1 es diferente a 0 es eliminado 

	SELECT  @Existe = -1
	IF @Existe1 <>  0 --que existe la acción en la arena
	BEGIN
			--insertar usuario			
			DELETE from TblArena_TblActions WHERE  IdArena=@IdArena AND IdAction=@IdAction;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdActionScenario]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar escenario de una acción 
-- Regresa 0 si eliminó 
-- =============================================

 CREATE PROCEDURE [dbo].[DelIdActionScenario] (
		@IdAction varchar (100),
		@IdScenario varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Existe1 int

	SELECT @Existe1=COUNT(*)	FROM TblScenarios WHERE  IdScenario=@IdScenario AND IdAction=@IdAction;
	SELECT  @Existe = -1
	IF @Existe1 <> 0
	BEGIN
		DELETE from TblScenarios WHERE  IdScenario=@IdScenario AND IdAction=@IdAction;
		SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdActionRoleActancial]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<eliminar RolActancial de una
-- funcionalidad,,> Regresa distinto a cero si es eliminado
-- Una acción sólo puede tener un rol actancial
-- =============================================
CREATE PROCEDURE [dbo].[DelIdActionRoleActancial] (
		@IdAction int,		
		@IdRoleAct int,
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Existe1 int
	
	SELECT @Existe1 = COUNT(*) FROM TblActions_TblRolesActancial WHERE IdAction= @IdAction AND IdRoleAct = @IdRoleAct;
	SELECT @Existe = -1

	IF @Existe1 <> 0
	BEGIN --Asignar rol actancial a una funcionalidad
		DELETE FROM TblActions_TblRolesActancial WHERE IdAction= @IdAction AND IdRoleAct = @IdRoleAct;
		SELECT @Existe = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelRoleActancial]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelRoleActancial] (
		@AtrName varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar rol actancial

	DECLARE @IdRoleAct int;
	EXEC @IdRoleAct = GetIdRoleActancial @AtrName
		
	SELECT @Existe = -1;
	
	IF @IdRoleAct <> -1 --que el rol actancial exista 
	BEGIN
			--eliminar rol actancial
			DELETE from TblRolesActancial WHERE  IdRoleAct=@IdRoleAct;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelRole]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelRole] (
		@AtrName varchar(50),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar rol

	DECLARE @IdRole int;
	EXEC @IdRole = GetIdRole @AtrName
		
	SELECT @Existe = -1;
	
	IF @IdRole <> -1 --que el rol exista 
	BEGIN
			--eliminar rol
			DELETE from TblRoles WHERE  IdRole=@IdRole;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelObject]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelObject] (
		@AtrName varchar(40),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar objeto

	DECLARE @IdObj int;
	EXEC @IdObj = GetIdObject @AtrName
	
	
	SELECT @Existe = -1;
	
	IF @IdObj <> -1 --que el objeto exista 
	BEGIN
			--eliminar actor
			DELETE from TblObjects WHERE  IdObj=@IdObj;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaScenarios]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar objetos,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaScenarios](
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--Mostrar objetos de una arena
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrName

	SELECT TblScenarios.IdScenario, TblScenarios.AtrName
	FROM TblScenarios,TblArenas
	WHERE
				TblScenarios.IdArena = TblArenas.IdArena AND
				TblScenarios.IdArena = @IdArena;

END
GO
/****** Object:  StoredProcedure [dbo].[GetActionRoleActancial]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<mostrar RolActancial de una
-- funcionalidad,,> Regresa 0 si se inserta
-- Una acción sólo puede tener un rol actancial
-- =============================================
CREATE PROCEDURE [dbo].[GetActionRoleActancial] (
		@AtrNameAction varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	--Agregar un rol actancial a una funcionalidad
	DECLARE @IdAction int;

	EXEC @IdAction = GetIdAction @AtrNameAction

	IF @IdAction <> -1 
	BEGIN --mostrar rol actancial a una funcionalidad
		SELECT  TblRolesActancial.IdRoleAct, TblRolesActancial.AtrName FROM TblActions, TblActions_TblRolesActancial, TblRolesActancial WHERE
				 TblActions.IdAction = TblActions_TblRolesActancial.IdAction AND
				 TblActions_TblRolesActancial.IdRoleAct = TblRolesActancial.IdRoleAct AND
				 TblActions.IdAction= @IdAction;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetActionScenarios]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar escenarios,,> 
-- =============================================

CREATE PROCEDURE [dbo].[GetActionScenarios] (
		@AtrName varchar(100)	
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar escenario de una acción

	DECLARE @IdAction int
	EXEC @IdAction = GetIdAction @AtrName
	
	IF @IdAction <> -1
	BEGIN
		SELECT TblScenarios.IdScenario, TblScenarios.AtrName, TblScenarios.AtrDescription FROM TblScenarios
		WHERE TblScenarios.IdAction = @IdAction
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActions]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenas,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaActions] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar acciones de las arenas

	
		SELECT TblActions.IdAction, TblActions.AtrName FROM TblActions, TblArenas, TblArena_TblActions 
		WHERE TblActions.IdAction = TblArena_TblActions.IdAction AND 
			  TblArenas.IdArena =  TblArena_TblActions.IdArena AND
			  TblArenas.AtrName = @AtrName;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdActorArena]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdActorArena] (
		@AtrNameActor varchar(40),
		@AtrNameArena varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdActor INT;	
	DECLARE @Existe INT;	

	SET @IdActor = -1;
	SET @Existe = -1;

	--Get Id Actor de un actor
	--Primero verificar actor este en la arena
	
	SELECT @Existe=COUNT(*) FROM TblActors, TblArenas, TblArena_TblActors
	WHERE
			TblActors.AtrName = @AtrNameActor AND
			TblArenas.AtrName = @AtrNameArena AND
			TblArena_TblActors.IdActor = TblActors.IdActor AND
			TblArena_TblActors.IdArena = TblArenas.IdArena

	IF @Existe > 0 --que el usuario  exista en la arena
	BEGIN
	  	--retornar id actor
		SELECT @IdActor=IdActor FROM TblActors WHERE AtrName=@AtrNameActor;
	END	

	RETURN @IdActor
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdProcessSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<getidtype sceanrio,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdProcessSentence] (
		@AtrName varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdProcess INT;	
	DECLARE @Existe INT;	

	SET @IdProcess = -1;
	SET @Existe = -1;


	IF (SELECT COUNT(*) FROM TblProcessSentences) < 2
	BEGIN
		EXEC AddScenarioProcess "Initialize",0
		EXEC AddScenarioProcess "Finalize",0
	END
	--Get Id process de un actor
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblProcessSentences WHERE
			TblProcessSentences.AtrName = @AtrName
	IF @Existe > 0 --que el tipo exista 
	BEGIN
	  	--mostrar process
		SELECT @IdProcess=IdProcess FROM TblProcessSentences WHERE AtrName=@AtrName;
	END	
	
	RETURN @IdProcess
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdActionArena]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdActionArena] (
		@AtrNameAction varchar(100),
		@AtrNameArena varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdAction INT;	
	DECLARE @Existe INT;	

	SET @IdAction = -1;
	SET @Existe = -1;

	--Get Id action de un actor
	--Primero verificar acción este en la arena
	
	SELECT @Existe=COUNT(*) FROM TblActions, TblArenas, TblArena_TblActions
	WHERE
			TblActions.AtrName = @AtrNameAction AND
			TblArenas.AtrName = @AtrNameArena AND
			TblArena_TblActions.IdAction = TblActions.IdAction AND
			TblArena_TblActions.IdArena = TblArenas.IdArena

	IF @Existe > 0 --que el usuario  exista en la arena
	BEGIN
	  	--retornar id action
		SELECT @IdAction=IdAction FROM TblActions WHERE AtrName=@AtrNameAction;
	END	

	RETURN @IdAction
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdArenaRoleActAction]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdArenaRoleActAction] (
		@AtrNameArena varchar(100),
		@AtrNameRoleAct varchar(100),
		@AtrNameAction varchar(100)	
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdRoleAct INT;	
	DECLARE @Existe INT;	

	SET @IdRoleAct = -1;
	SET @Existe = -1;

	--Get Id rol
	--Primero verificar funcionalidad  este en la arena rolactancial
	
	SELECT @Existe=COUNT(*) FROM TblRolesActancial, TblActions,TblArena_TblAction_TblRoleActancial, TblArenas
	WHERE
			TblRolesActancial.AtrName = @AtrNameRoleAct AND
			TblArenas.AtrName = @AtrNameArena AND
			TblActions.AtrName = @AtrNameAction AND
			TblArena_TblAction_TblRoleActancial.IdArena =  TblArenas.IdArena AND
			TblArena_TblAction_TblRoleActancial.IdRoleAct =  TblRolesActancial.IdRoleAct AND
			TblArena_TblAction_TblRoleActancial.IdAction = TblActions.IdAction

	IF @Existe > 0 --que el rol actancial  exista en la arena y la funcionalidad
	BEGIN
	  	--retornar id actor
		SELECT @IdRoleAct=IdRoleAct FROM TblRolesActancial WHERE AtrName=@AtrNameRoleAct;
	END	
	RETURN @IdRoleAct
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaRolesActancial]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenas,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaRolesActancial] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles actanciales de la arena

	
		SELECT TblRolesActancial.IdRoleAct, TblRolesActancial.AtrName FROM TblRolesActancial, TblArenas, TblArena_TblRolesActancial 
		WHERE TblRolesActancial.IdRoleAct = TblArena_TblRolesActancial.IdRoleAct AND 
			  TblArenas.IdArena =  TblArena_TblRolesActancial.IdArena AND
			  TblArenas.AtrName = @AtrName;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaRoles]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar roles arena,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaRoles] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles de las arenas

		SELECT TblRoles.IdRole,TblRoles.AtrName FROM TblRoles, TblArenas, TblArena_TblRoles 
		WHERE TblRoles.IdRole = TblArena_TblRoles.IdRole AND 
			  TblArenas.IdArena =  TblArena_TblRoles.IdArena AND
			  TblArenas.AtrName = @AtrName;

END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaObjects]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar objetos,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaObjects](
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--Mostrar objetos de una arena
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrName

	SELECT TblObjects.IdObj AS IdObj, TblObjects.AtrName AS AtrName, TblObjects.AtrVal AS AtrVal FROM TblObjects,TblArenas, TblArena_TblObjects
	WHERE
				TblObjects.IdObj = TblArena_TblObjects.IdObj AND
				TblArenas.IdArena = TblArena_TblObjects.IdArena AND
				TblArenas.IdArena = @IdArena

END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActorsRoles]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenas,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaActorsRoles] (
		@AtrNameArena varchar(100)
		--@AtrNameRole varchar(50),
		--@AtrNameActor varchar(40),
		
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles con actores de una arena

	SET NOCOUNT ON;
	--Agregar un rol a un actor de una arena
	DECLARE @IdArena int;
	--DECLARE @IdActor int;
	--DECLARE @IdRole int;

	EXEC @IdArena = GetIdArena @AtrNameArena
	--EXEC @IdActor = GetIdActorArena @AtrNameActor
	--EXEC @IdRole = GetIdRoleArena @AtrNameRole

	
	SELECT TblActors.IdActor, TblActors.AtrName AS AtrNameActor, TblRoles.IdRole, TblRoles.AtrName AS AtrNameRole FROM TblArena_TblActor_TblRole, TblArenas, TblRoles, TblActors
			WHERE
				TblArena_TblActor_TblRole.IdArena = @IdArena AND
				TblArena_TblActor_TblRole.IdActor = TblActors.IdActor AND
				TblArena_TblActor_TblRole.IdRole = TblRoles.IdRole AND
				TblArena_TblActor_TblRole.IdArena = TblArenas.IdArena
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActors]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenas,,> 
--Regresa número de actores de arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaActors] (
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar actores de las arenas
	
		SELECT TblActors.IdActor, TblActors.AtrName FROM TblActors, TblArenas, TblArena_TblActors 
		WHERE TblActors.IdActor = TblArena_TblActors.IdActor AND 
			  TblArenas.IdArena =  TblArena_TblActors.IdArena AND
			  TblArenas.AtrName = @AtrName;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdScenario1]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<getId de escenario,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdScenario1] (
		@AtrNameArena  varchar(100),
		@AtrNameScenario varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Existe INT;	

	DECLARE @IdArena INT; 
	EXEC @IdArena = GetIdArena @AtrNameArena;

	SET @Existe = -1;
	
	--Get Id Scenario
	--Primero verificar que el nivel de usuario exista
	SELECT @Existe=COUNT(*) FROM TblScenarios WHERE
			TblScenarios.AtrName = @AtrNameScenario AND IdArena = @IdArena
	IF @Existe > 0 --que kla arena exista 
	BEGIN
	  	--seleccionar id escenario
		SELECT IdScenario FROM TblScenarios WHERE AtrName=@AtrNameScenario AND IdArena = @IdArena;
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdScenario]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<getId de escenario,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdScenario] (
		@IdArena int,
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdScenario INT;	
	DECLARE @Existe INT;	

	SET @IdScenario = -1;
	SET @Existe = -1;

	
	--Get Id Scenario
	--Primero verificar que el nivel de usuario exista
	
	SELECT @Existe=COUNT(*) FROM TblScenarios WHERE
			TblScenarios.AtrName = @AtrName AND IdArena = @IdArena
	IF @Existe > 0 --que kla arena exista 
	BEGIN
	  	--seleccionar id escenario
		SELECT @IdScenario=IdScenario FROM TblScenarios WHERE AtrName=@AtrName AND IdArena = @IdArena;
	END	
	RETURN @IdScenario
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdRoleArena]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddActor,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdRoleArena] (
		@AtrNameRole varchar(50),
		@AtrNameArena varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdRole INT;	
	DECLARE @Existe INT;	

	SET @IdRole = -1;
	SET @Existe = -1;

	--Get Id rol
	--Primero verificar rol este en la arena
	
	SELECT @Existe=COUNT(*) FROM TblRoles, TblArenas, TblArena_TblRoles
	WHERE
			TblRoles.AtrName = @AtrNameRole AND
			TblArenas.AtrName = @AtrNameArena AND
			TblArena_TblRoles.IdArena =  TblArenas.IdArena AND
			TblArena_TblRoles.IdRole =  TblRoles.IdRole 

	IF @Existe > 0 --que el usuario  exista en la arena
	BEGIN
	  	--retornar id actor
		SELECT @IdRole=IdRole FROM TblRoles WHERE AtrName=@AtrNameRole;
	END	
	RETURN @IdRole
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdTypeSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<getidtype sceanrio,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdTypeSentence] (
		@AtrName varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdType INT;	
	DECLARE @Existe INT;	

	SET @IdType = -1;
	SET @Existe = -1;

	--Get Id Actor de un actor
	--Primero verificar que el nivel de usuario exista
	
	IF (SELECT COUNT(*) FROM TblTypesSentences) < 2
	BEGIN
		EXEC AddScenarioType "Precondition",0
		EXEC AddScenarioType "Poscondition",0
	END


	SELECT @Existe=COUNT(*) FROM TblTypesSentences WHERE
			TblTypesSentences.AtrName = @AtrName
	IF @Existe > 0 --que el tipo exista 
	BEGIN
	  	--insertar usuario			
		SELECT @IdType=IdType FROM TblTypesSentences WHERE AtrName=@AtrName;
	END	
	
	RETURN @IdType
END
GO
/****** Object:  Table [dbo].[TblSentences]    Script Date: 06/21/2014 09:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblSentences](
	[idSentence] [int] IDENTITY(1,1) NOT NULL,
	[AtrSentence] [varchar](500) NOT NULL,
	[idType] [int] NOT NULL,
	[idProcess] [int] NOT NULL,
	[idScenario] [int] NOT NULL,
 CONSTRAINT [PK_TblSentences] PRIMARY KEY CLUSTERED 
(
	[idSentence] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[updateScenario]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar datos del escenario
-- Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateScenario](
	@IdScenario int, 
	@AtrNameScenarioUpdate varchar(100), 
	@AtrNameDescriptionUpdate text, 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblScenarios WHERE
		IdScenario = @IdScenario
	--Si existe la acción entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblScenarios
		SET
			AtrName = @AtrNameScenarioUpdate,
			AtrDescription = @AtrNameDescriptionUpdate
		WHERE IdScenario=@IdScenario
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActionsRolesAct]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar roles actanciales con funcionalidades de
-- la arena,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaActionsRolesAct] (
		@AtrNameArena varchar(100)
		--@AtrNameAction varchar(100),
		--@AtrNameRole varchar(50),
		--@AtrNameActor varchar(40),
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles con actores de una arena

	SET NOCOUNT ON;
	--Agregar un rol a un actor de una arena
	DECLARE @IdArena int;
	--DECLARE @IdActor int;
	--DECLARE @IdRole int;

	EXEC @IdArena = GetIdArena @AtrNameArena
	--EXEC @IdActor = GetIdActorArena @AtrNameActor
	--EXEC @IdRole = GetIdRoleArena @AtrNameRole


	IF @IdArena <> -1 
	BEGIN
			SELECT TblActions.AtrName AS AtrNameAction, TblRolesActancial.AtrName AS AtrNameRoleAct FROM TblArena_TblAction_TblRoleActancial, TblArenas, TblRolesActancial, TblActions
			WHERE
				TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
				--TblArena_TblActor_TblRole.IdActor = @IdActor AND
				--TblArena_TblActor_TblRole.IdRole = @IdRole AND
				TblArena_TblAction_TblRoleActancial.IdAction = TblActions.IdAction AND
				TblArena_TblAction_TblRoleActancial.IdRoleAct = TblRolesActancial.IdRoleAct AND
				TblArena_TblAction_TblRoleActancial.IdArena = TblArenas.IdArena
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActionScenarioData]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddRolArena,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[GetArenaActionScenarioData] (
		@AtrNameArena varchar(100),
		@AtrNameAction varchar (100),
		@AtrNameScenario varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar scenario a una funcionalidad definida en
	--una arena

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @IdArena, @AtrNameScenario

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdActionArena @AtrNameAction,@AtrNameArena

	
	--SELECT (@IdScenario)
	--SELECT (@IdAction)
	--SELECT (@IdArena)
	IF @IdScenario <> -1 AND @IdArena <> -1 AND @IdAction <> -1 --que el usuario no exista 
	BEGIN
			--mostrar escenario de una funcionalidad
			SELECT TblScenarios.IdScenario,TblScenarios.AtrName, TblScenarios.AtrDescription,TblScenarios.IdAction, TblScenarios.IdArena FROM TblScenarios WHERE IdScenario = @IdScenario AND
			IdArena = @IdArena AND IdAction = @IdAction;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActionScenario]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<Get scenarios de la acción,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[GetArenaActionScenario] (
		@AtrNameArena varchar(100),
		@AtrNameAction varchar (100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar scenario a una funcionalidad definida en
	--una arena

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdActionArena @AtrNameAction,@AtrNameArena

	--mostrar escenario de una funcionalidad
	SELECT TblScenarios.IdScenario, TblScenarios.AtrName 
		FROM TblScenarios
		WHERE TblScenarios.IdAction=@IdAction AND TblScenarios.IdArena = @IdArena;
	

	
END
GO
/****** Object:  StoredProcedure [dbo].[updateSentenceType]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar datos del escenario
-- Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateSentenceType](
	@IdSentence int, 
	@AtrNameTypeUpdate varchar(50), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblSentences WHERE
		IdSentence = @IdSentence
	
	DECLARE @IdType int
	EXEC  @IdType= GetIdTypeSentence @AtrNameTypeUpdate

	--Si existe la sentencia entonces lo actualiza
	IF @Existe<>0 AND @IdType <> -1
	BEGIN
		UPDATE TblSentences
		SET
			IdType = @IdType
		WHERE IdSentence=@IdSentence
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateSentenceProcess]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar datos del escenario
-- Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateSentenceProcess](
	@IdSentence int, 
	@AtrNameProcessUpdate varchar(50), 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblSentences WHERE
		IdSentence = @IdSentence
	
	DECLARE @IdProcess int
	EXEC @IdProcess = GetIdProcessSentence @AtrNameProcessUpdate
	
	--Si existe la sentencia entonces lo actualiza
	IF @Existe<>0 AND @IdProcess <> -1
	BEGIN
		UPDATE TblSentences
		SET
			IdProcess = @IdProcess
		WHERE IdSentence=@IdSentence
	END
END
GO
/****** Object:  StoredProcedure [dbo].[updateSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Modificar datos del escenario
-- Regresa <>0 si modificó
-- =============================================
CREATE PROCEDURE [dbo].[updateSentence](
	@IdSentence int, 
	@AtrNameSentenceUpdate text, 
	@Existe int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @Existe=COUNT(*) FROM TblSentences WHERE
		IdSentence = @IdSentence
	--Si existe la sentencia entonces lo actualiza
	IF @Existe<>0
	BEGIN
		UPDATE TblSentences
		SET
			AtrSentence = @AtrNameSentenceUpdate
		WHERE IdSentence=@IdSentence
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetScenarioSentences]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar sentences,,> 
-- =============================================

CREATE  PROCEDURE [dbo].[GetScenarioSentences] (
		@AtrNameArena varchar(100),
		@AtrName varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar sentencias
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @IdArena,@AtrName

	IF @IdScenario <> -1 --entonces existe
	BEGIN	
		SELECT TblSentences.IdSentence, TblSentences.AtrSentence,
				TblProcessSentences.AtrName AS AtrProcess, TblTypesSentences.AtrName AS AtrType FROM TblSentences, TblProcessSentences, TblTypesSentences
		WHERE TblSentences.IdScenario = @IdScenario AND 
				TblTypesSentences.IdType =  TblSentences.IdType AND
				TblProcessSentences.IdProcess = TblSentences.IdProcess;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<getidsentencia,,> Regresa -1 sino existe
-- =============================================
CREATE PROCEDURE [dbo].[GetIdSentence] (
		@AtrName varchar(500)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdSentence INT;	
	DECLARE @Existe INT;	

	SET @IdSentence = -1;
	SET @Existe = -1;

	--Get Id sentence de una sentencia
		
	IF @Existe > 0 --que el tipo exista 
	BEGIN
	  	--get ID			
		SELECT @IdSentence=IdSentence FROM TblSentences WHERE AtrSentence=@AtrName;
	END	
	
	RETURN @IdSentence
END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActorRole]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar arenas,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaActorRole] (
		@AtrNameArena varchar(100),
		--@AtrNameRole varchar(50),
		@AtrNameActor varchar(40)
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles con actores de una arena

	SET NOCOUNT ON;
	--Agregar un rol a un actor de una arena
	DECLARE @IdArena int;
	DECLARE @IdActor int;
	--DECLARE @IdRole int;

	EXEC @IdArena = GetIdArena @AtrNameArena
	EXEC @IdActor = GetIdActorArena @AtrNameActor,@AtrNameArena
	--EXEC @IdRole = GetIdRoleArena @AtrNameRole

	
	SELECT TblActors.IdActor,TblActors.AtrName AS AtrNameActor, TblRoles.AtrName AS AtrNameRole FROM TblArena_TblActor_TblRole, TblArenas, TblRoles, TblActors
    WHERE
				TblArena_TblActor_TblRole.IdArena = @IdArena AND
				TblArena_TblActor_TblRole.IdActor = @IdActor AND
				--TblArena_TblActor_TblRole.IdActor = @IdActor AND
				--TblArena_TblActor_TblRole.IdRole = @IdRole AND
				TblArena_TblActor_TblRole.IdActor = TblActors.IdActor AND
				TblArena_TblActor_TblRole.IdRole = TblRoles.IdRole AND
				TblArena_TblActor_TblRole.IdArena = TblArenas.IdArena

END
GO
/****** Object:  StoredProcedure [dbo].[GetArenaActionRoleAct]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<mostrar roles actanciales con funcionalidades de
-- la arena,,> 
--Regresa número de acciones arena en Number
-- =============================================

CREATE PROCEDURE [dbo].[GetArenaActionRoleAct] (
		@AtrNameArena varchar(100),
		@AtrNameAction varchar(100),
		--@AtrNameRole varchar(50),
		--@AtrNameActor varchar(40),
		@Number int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--mostrar roles con actores de una arena

	SET NOCOUNT ON;
	--Agregar un rol a un actor de una arena
	DECLARE @IdArena int;
	DECLARE @IdAction int;
	--DECLARE @IdRole int;


	EXEC @IdArena = GetIdArena @AtrNameArena
	EXEC @IdAction = GetIdActionArena @AtrNameAction, @AtrNameArena
	--EXEC @IdRole = GetIdRoleArena @AtrNameRole

	IF @IdAction <> -1 AND @IdArena <> -1
	BEGIN
		SELECT @Number=COUNT(*) FROM TblArena_TblAction_TblRoleActancial, TblArenas, TblRolesActancial, TblActions
		WHERE
				TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
				TblArena_TblAction_TblRoleActancial.IdAction = @IdAction AND
				--TblArena_TblActor_TblRole.IdActor = @IdActor AND
				--TblArena_TblActor_TblRole.IdRole = @IdRole AND
				TblArena_TblAction_TblRoleActancial.IdAction = TblActions.IdAction AND
				TblArena_TblAction_TblRoleActancial.IdRoleAct = TblRolesActancial.IdRoleAct AND
				TblArena_TblAction_TblRoleActancial.IdArena = TblArenas.IdArena 
			
		IF @Number > 0
		BEGIN
			SELECT TblRolesActancial.IdRoleAct , TblActions.AtrName AS AtrNameAction, TblRolesActancial.AtrName AS AtrNameRoleAct FROM TblArena_TblAction_TblRoleActancial, TblArenas, TblRolesActancial, TblActions
			WHERE
				TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
				TblArena_TblAction_TblRoleActancial.IdAction = @IdAction AND
				TblArena_TblAction_TblRoleActancial.IdAction = TblActions.IdAction AND
				TblArena_TblAction_TblRoleActancial.IdRoleAct = TblRolesActancial.IdRoleAct AND
				TblArena_TblAction_TblRoleActancial.IdArena = TblArenas.IdArena
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelScenarioType]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar tipo de escenario,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelScenarioType] (
		@AtrName varchar(50),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar tipo de escenario

	DECLARE @IdType1 int;
				
	EXEC @IdType1 = GetIdTypeSentence @AtrName
	
	SELECT @Existe = -1;
	
	IF @IdType1 <> -1 --que el tipo exista 
	BEGIN
			--eliminar actor
			DELETE from TblTypesSentences WHERE  IdType=@IdType1;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelScenarioSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar tipo de escenario,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelScenarioSentence] (
		@AtrNameScenario varchar(100),
		@IdSentence int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar sentencia de escenario
	

	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @AtrNameScenario
	
	
	SELECT @Existe = -1;
	
	IF @IdScenario <> -1 --que el sentencia y escenario existan
	BEGIN
		IF (SELECT COUNT(*) from TblSentences WHERE  IdSentence=@IdSentence AND IdScenario = @IdScenario) > 0
		BEGIN
			--eliminar sentencia
			DELETE from TblSentences WHERE  IdSentence=@IdSentence AND IdScenario = @IdScenario;
			SELECT  @Existe = 0
		END
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelScenarioProcess]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar tipo de escenario,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelScenarioProcess] (
		@AtrName varchar(50),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar proceso de escenario
	--initialize
	--finalize

	DECLARE @IdProcess int;
				
	EXEC @IdProcess = GetIdProcessSentence @AtrName
	
	SELECT @Existe = -1;
	
	IF @IdProcess <> -1 --que el tipo exista 
	BEGIN
			--eliminar actor
			DELETE from TblProcessSentences WHERE  IdProcess=@IdProcess;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[DelIdScenarioSentence]    Script Date: 06/21/2014 09:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar tipo de escenario,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelIdScenarioSentence] (
		@IdScenario int,
		@IdSentence int,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--eliminar sentencia de escenario
	
	SELECT @Existe = -1;

	IF (SELECT COUNT(*) from TblSentences WHERE  IdSentence=@IdSentence AND IdScenario = @IdScenario) > 0
	BEGIN
			--eliminar sentencia
			DELETE from TblSentences WHERE  IdSentence=@IdSentence AND IdScenario = @IdScenario;
			SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaActorRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <18Nov06,,>
-- Description:	<AddRolActor,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddArenaActorRole] (
		@AtrNameArena varchar(100),
		@AtrNameActor varchar(40),
		@AtrNameRole varchar(50),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT @Existe=-1
	--Agregar un rol a un actor de una arena
	DECLARE @IdArena int;
	DECLARE @IdActor int;
	DECLARE @IdRole int;

	EXEC @IdArena = GetIdArena @AtrNameArena
	EXEC @IdActor = GetIdActorArena @AtrNameActor,@AtrNameArena
	EXEC @IdRole = GetIdRoleArena @AtrNameRole,@AtrNameArena

	IF @IdArena <> -1 AND @IdActor <> -1 AND
		@IdRole <> -1 
	BEGIN --Asignar actor al rol
		SELECT @Existe=COUNT(*) FROM TblArena_TblActor_TblRole
		WHERE
			TblArena_TblActor_TblRole.IdArena = @IdArena AND
			TblArena_TblActor_TblRole.IdActor = @IdActor AND
			TblArena_TblActor_TblRole.IdRole = @IdRole
		IF @Existe = 0 --que el usuario no exista 
		BEGIN
				INSERT INTO TblArena_TblActor_TblRole VALUES (@IdArena,@IdActor,@IdRole);
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddActionScenario]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddActionArena,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddActionScenario] (
		@AtrNameArena varchar (100),
		@AtrNameAction varchar (100),
		@AtrNameScenario varchar(100),
		@AtrDescription text,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar scenario acción 

	SELECT  @Existe = -1 --No ha sido insertado
	--Insertar scenario a Acción 

	--EXEC AddAction @AtrNameAction,0
		
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdAction @AtrNameArena

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdAction @AtrNameAction

	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @AtrNameScenario

	--Que existe la acción y q el escenario no existe
	IF @IdAction <> -1  AND @IdScenario = -1
	BEGIN
			--insertar scenario 
			INSERT INTO TblScenarios VALUES (@AtrNameScenario, @AtrDescription, @IdAction,@IdArena);
			SELECT  @Existe = 0
		
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaActionRoleAct]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddRolArena,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddArenaActionRoleAct] (
		@AtrNameArena varchar(100),
		@AtrNameRoleAct varchar(100),
		@AtrNameAction varchar (100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar rol a arena

	--EXEC AddRoleActancial @AtrNameRoleAct,0

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @IdRoleAct int;
	EXEC @IdRoleAct = GetIdRoleActancial @AtrNameRoleAct

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdActionArena @AtrNameAction,@AtrNameArena

	SELECT @Existe=-1
	IF @IdRoleAct <> -1 AND @IdArena <> -1 AND @IdAction <> -1 --que el usuario no exista 
	BEGIN
		DECLARE @Existe1 int;
		SET @Existe1 = 0;

		SELECT @Existe1=COUNT(*) FROM TblArena_TblAction_TblRoleActancial WHERE
			TblArena_TblAction_TblRoleActancial.IdAction = @IdAction AND
			TblArena_TblAction_TblRoleActancial.IdRoleAct = @IdRoleAct AND
			TblArena_TblAction_TblRoleActancial.IdArena = @IdArena 
		--Si Existe1 es igual 0 es insertado 

		SELECT  @Existe = -1 --No ha sido insertado
			
		IF @Existe1 = 0 AND (SELECT COUNT(*) FROM TblArena_TblRolesActancial WHERE
			TblArena_TblRolesActancial.IdRoleAct = @IdRoleAct AND
			TblArena_TblRolesActancial.IdArena = @IdArena) > 0  --que el usuario no exista 
		BEGIN
			--insertar rol actancial a una funcionalidad
			INSERT INTO TblArena_TblAction_TblRoleActancial VALUES (@IdArena,@IdAction,@IdRoleAct);
			SELECT  @Existe = 0
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaActorRole]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar actor de una arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaActorRole] (
		@AtrNameArena varchar(100),
		--@AtrNameRole varchar(50),
		@AtrNameActor varchar(40),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	--Elimnar rol a un actor

	DECLARE @IdActor int;
	EXEC @IdActor = GetIdActorArena @AtrNameActor,@AtrNameArena
	
	--DECLARE @IdRole int;
	--EXEC @IdRole = GetIdRoleArena @AtrNameRole

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	
	DECLARE @Existe1 int;
	SET @Existe1 = -1;
	SELECT  @Existe = -1 --No ha sido insertado

	IF @IdActor <> -1 AND @IdArena <> -1-- AND @IdRole <> -1
	BEGIN
		SELECT @Existe1=COUNT(*) FROM TblArena_TblActor_TblRole WHERE
			TblArena_TblActor_TblRole.IdArena = @IdArena AND
			TblArena_TblActor_TblRole.IdActor = @IdActor --AND
			--TblArena_TblActor_TblRole.IdRole = @IdRole

		--Si Existe1 es diferente a 0 es eliminado 
	
		IF @Existe1 <>  0 
		BEGIN
			--eliminar usuario			
			DELETE from TblArena_TblActor_TblRole WHERE  
				TblArena_TblActor_TblRole.IdArena = @IdArena AND
				TblArena_TblActor_TblRole.IdActor = @IdActor --AND
			--	TblArena_TblActor_TblRole.IdRole = @IdRole
			SELECT  @Existe = 0
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaActionScenario]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddRolArena,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[DelArenaActionScenario] (
		@AtrNameArena varchar(100),
		@AtrNameAction varchar (100),
		@AtrNameScenario varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar scenario a una funcionalidad definida en
	--una arena

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @AtrNameScenario

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdActionArena @AtrNameAction,@AtrNameArena

	SELECT @Existe=-1

	IF @IdScenario <> -1 AND @IdArena <> -1 AND @IdAction <> -1 --que el usuario no exista 
	BEGIN
			--eliminar scenario actancial a una funcionalidad
			DELETE FROM TblScenarios WHERE IdScenario = @IdScenario;
			SELECT  @Existe = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelArenaActionRoleAct]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar rol actancial de una 
-- funcionalidad en la arena,,> Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelArenaActionRoleAct] (
		@AtrNameArena varchar(100),
		--@AtrNameRole varchar(50),
		@AtrNameAction varchar(100),
		@Existe int output	
)
AS
BEGIN
	SET NOCOUNT ON;
	--Elimnar rol actancial a una acción a un actor

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdActionArena @AtrNameAction,@AtrNameArena
	
	--DECLARE @IdRole int;
	--EXEC @IdRole = GetIdRoleArena @AtrNameRole

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	
	DECLARE @Existe1 int;
	SET @Existe1 = -1;
	SELECT  @Existe = -1 --No ha sido insertado

	IF @IdAction <> -1 AND @IdArena <> -1-- AND @IdRole <> -1
	BEGIN
		SELECT @Existe1=COUNT(*) FROM TblArena_TblAction_TblRoleActancial WHERE
			TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
			TblArena_TblAction_TblRoleActancial.IdAction = @IdAction --AND
			--TblArena_TblActor_TblRole.IdRole = @IdRole

		--Si Existe1 es diferente a 0 es eliminado 
	
		IF @Existe1 <>  0 
		BEGIN
			--eliminar usuario			
			DELETE from TblArena_TblAction_TblRoleActancial WHERE  
				TblArena_TblAction_TblRoleActancial.IdArena = @IdArena AND
				TblArena_TblAction_TblRoleActancial.IdAction = @IdAction --AND
			--	TblArena_TblActor_TblRole.IdRole = @IdRole
			SELECT  @Existe = 0
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DelActionScenario]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<eliminar escenario de una acción 
-- Regresa 0 si eliminó 
-- =============================================

CREATE PROCEDURE [dbo].[DelActionScenario] (
		@AtrNameArena varchar (100),
		@AtrNameAction varchar (100),
		@AtrNameScenario varchar(100),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  @Existe = -1 --No ha sido insertado

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdAction @AtrNameAction
	

	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @AtrNameScenario
	

	IF @IdAction <> -1 AND  @IdScenario <> -1
	BEGIN
		DELETE from TblScenarios WHERE  IdScenario=@IdScenario AND IdAction=@IdAction;
		SELECT  @Existe = 0
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[AddScenarioSentence]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddSentencia a un escenario,,> Regresa 0 si se inserta
-- =============================================

CREATE PROCEDURE [dbo].[AddScenarioSentence] (
		@AtrNameArena varchar(100),
		@AtrNameScenario varchar(100),	
		@AtrNameSentence varchar(500),
		@AtrNameType varchar (50),
		@AtrNameProcess varchar (50),
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar actor a arena

	SELECT  @Existe = -1 --No ha sido insertado
				
	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena
	DECLARE @IdScenario int;
	EXEC @IdScenario = GetIdScenario @IdArena, @AtrNameScenario
	DECLARE @IdType int;
	EXEC @IdType = GetIdTypeSentence @AtrNameType
	DECLARE @IdProcess int;
	EXEC @IdProcess = GetIdProcessSentence @AtrNameProcess

	DECLARE @Number INT;
	SELECT @Number = IdSentence FROM TblSentences WHERE 
			IdType = @IdType AND 
			IdProcess = @IdProcess AND
			IdScenario =@IdScenario;
	
	DECLARE @AtrNameAction varchar(100);
	SELECT @AtrNameAction = TblActions.AtrName FROM TblScenarios, TblActions WHERE
			TblActions.IdAction = TblScenarios.IdAction AND
			TblScenarios.IdScenario = @IdScenario;


		
	IF @Number > 0
	BEGIN
			EXEC updateSentence @Number,@AtrNameSentence, @Number
			IF @Number <> 0 
					SELECT  @Existe = 0
	END	

	ELSE
	BEGIN
		IF @IdScenario <> -1 AND @IdType <> -1 AND @IdProcess <> -1 
		BEGIN
			--insertar sentencia en el escenario 
			INSERT INTO TblSentences VALUES (@AtrNameSentence,@IdType,@IdProcess, @IdScenario);
			SELECT  @Existe = 0
		
		END
	END		
END
GO
/****** Object:  StoredProcedure [dbo].[AddArenaActionScenario]    Script Date: 06/21/2014 09:49:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Dic07,,>
-- Description:	<AddRolArena,,> Regresa 0 si se inserta
-- =============================================
CREATE PROCEDURE [dbo].[AddArenaActionScenario] (
		@AtrNameArena varchar(100),
		@AtrNameAction varchar (100),
		@AtrNameScenario varchar(100),
		@AtrDescription text,
		@Existe int output
)
AS
BEGIN
	SET NOCOUNT ON;
	--Agregar scenario a una funcionalidad definida en
	--una arena

	DECLARE @IdArena int;
	EXEC @IdArena = GetIdArena @AtrNameArena

	DECLARE @IdAction int;
	EXEC @IdAction = GetIdActionArena @AtrNameAction,@AtrNameArena

	DECLARE @Existe1 int;
	SELECT @Existe1 = COUNT(*) FROM TblScenarios WHERE AtrName = @AtrNameScenario
		 AND IdArena = @IdArena AND IdAction = @IdAction
	
	SELECT @Existe=-1

	IF @Existe1 = 0 AND @IdArena <> -1 AND @IdAction <> -1 --que el no exista 
	BEGIN
			--insertar escenario
			INSERT INTO TblScenarios VALUES (@AtrNameScenario,@AtrDescription,@IdAction,@IdArena);
			SELECT  @Existe = 0

			DECLARE @AtrS varchar(500);
			SELECT @AtrS = 'Arenas:{"' + @AtrNameArena  + '"}::(Arenas);'+ char(13) + char(10)+'Actions:{"'+ @AtrNameAction  +  '"}::Arenas:{"' + @AtrNameArena + '"};';
			
			DECLARE @AtrS1 varchar(500);
			SELECT @AtrS1 = 'Actions:{"' + @AtrNameAction + '"};';
		
			--Agregar sentencia que condiciona la inicialización
			EXEC AddScenarioSentence  @AtrNameArena, @AtrNameScenario,@AtrS,'Precondition','Initialize',0
			--Agregar sentencia que condiciona la inicialización,finalización en poscondiciones
			EXEC AddScenarioSentence  @AtrNameArena, @AtrNameScenario,@AtrS1,'Precondition','Finalize',0
			EXEC AddScenarioSentence  @AtrNameArena, @AtrNameScenario,'Exit','Poscondition','Finalize',0
			
	END
END
GO
/****** Object:  ForeignKey [FK_TblActions_TblActors_TblActions11]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblActions_TblActors]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblActors_TblActions11] FOREIGN KEY([idAction])
REFERENCES [dbo].[TblActions] ([idAction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblActions_TblActors] CHECK CONSTRAINT [FK_TblActions_TblActors_TblActions11]
GO
/****** Object:  ForeignKey [FK_TblActions_TblActors_TblActors]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblActions_TblActors]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblActors_TblActors] FOREIGN KEY([idActor])
REFERENCES [dbo].[TblActors] ([idActor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblActions_TblActors] CHECK CONSTRAINT [FK_TblActions_TblActors_TblActors]
GO
/****** Object:  ForeignKey [FK_TblActions_TblRoles_TblActions1]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblActions_TblRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblRoles_TblActions1] FOREIGN KEY([idAction])
REFERENCES [dbo].[TblActions] ([idAction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblActions_TblRoles] CHECK CONSTRAINT [FK_TblActions_TblRoles_TblActions1]
GO
/****** Object:  ForeignKey [FK_TblActions_TblRoles_TblRoles]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblActions_TblRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblRoles_TblRoles] FOREIGN KEY([idRole])
REFERENCES [dbo].[TblRoles] ([idRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblActions_TblRoles] CHECK CONSTRAINT [FK_TblActions_TblRoles_TblRoles]
GO
/****** Object:  ForeignKey [FK_TblActions_TblRolesActancial_TblActions]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblActions_TblRolesActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblRolesActancial_TblActions] FOREIGN KEY([idAction])
REFERENCES [dbo].[TblActions] ([idAction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblActions_TblRolesActancial] CHECK CONSTRAINT [FK_TblActions_TblRolesActancial_TblActions]
GO
/****** Object:  ForeignKey [FK_TblActions_TblRolesActancial_TblRolesActancial1]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblActions_TblRolesActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblRolesActancial_TblRolesActancial1] FOREIGN KEY([idRoleAct])
REFERENCES [dbo].[TblRolesActancial] ([idRoleAct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblActions_TblRolesActancial] CHECK CONSTRAINT [FK_TblActions_TblRolesActancial_TblRolesActancial1]
GO
/****** Object:  ForeignKey [FK_TblActions_TblRolesActancial_TblActions1]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblAction_TblRoleActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblRolesActancial_TblActions1] FOREIGN KEY([idAction])
REFERENCES [dbo].[TblActions] ([idAction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblAction_TblRoleActancial] CHECK CONSTRAINT [FK_TblActions_TblRolesActancial_TblActions1]
GO
/****** Object:  ForeignKey [FK_TblActions_TblRolesActancial_TblRolesActancial]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblAction_TblRoleActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblActions_TblRolesActancial_TblRolesActancial] FOREIGN KEY([idRoleAct])
REFERENCES [dbo].[TblRolesActancial] ([idRoleAct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblAction_TblRoleActancial] CHECK CONSTRAINT [FK_TblActions_TblRolesActancial_TblRolesActancial]
GO
/****** Object:  ForeignKey [FK_TblArena_TblAction_TblRolesActancial_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblAction_TblRoleActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblAction_TblRolesActancial_TblArenas] FOREIGN KEY([idArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblAction_TblRoleActancial] CHECK CONSTRAINT [FK_TblArena_TblAction_TblRolesActancial_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActions_TblActions]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActions]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActions_TblActions] FOREIGN KEY([idAction])
REFERENCES [dbo].[TblActions] ([idAction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActions] CHECK CONSTRAINT [FK_TblArena_TblActions_TblActions]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActions_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActions]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActions_TblArenas] FOREIGN KEY([idArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActions] CHECK CONSTRAINT [FK_TblArena_TblActions_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActor_TblRol_TblActors]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActor_TblRole]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActor_TblRol_TblActors] FOREIGN KEY([idActor])
REFERENCES [dbo].[TblActors] ([idActor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActor_TblRole] CHECK CONSTRAINT [FK_TblArena_TblActor_TblRol_TblActors]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActor_TblRol_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActor_TblRole]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActor_TblRol_TblArenas] FOREIGN KEY([idArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActor_TblRole] CHECK CONSTRAINT [FK_TblArena_TblActor_TblRol_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActor_TblRol_TblRoles]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActor_TblRole]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActor_TblRol_TblRoles] FOREIGN KEY([idRole])
REFERENCES [dbo].[TblRoles] ([idRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActor_TblRole] CHECK CONSTRAINT [FK_TblArena_TblActor_TblRol_TblRoles]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActor_TblRolActancial_TblActors]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActor_TblRoleActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActor_TblRolActancial_TblActors] FOREIGN KEY([idActor])
REFERENCES [dbo].[TblActors] ([idActor])
GO
ALTER TABLE [dbo].[TblArena_TblActor_TblRoleActancial] CHECK CONSTRAINT [FK_TblArena_TblActor_TblRolActancial_TblActors]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActor_TblRolActancial_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActor_TblRoleActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActor_TblRolActancial_TblArenas] FOREIGN KEY([idArena])
REFERENCES [dbo].[TblArenas] ([idArena])
GO
ALTER TABLE [dbo].[TblArena_TblActor_TblRoleActancial] CHECK CONSTRAINT [FK_TblArena_TblActor_TblRolActancial_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActor_TblRolActancial_TblRolesActancial]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActor_TblRoleActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActor_TblRolActancial_TblRolesActancial] FOREIGN KEY([idRolAct])
REFERENCES [dbo].[TblRolesActancial] ([idRoleAct])
GO
ALTER TABLE [dbo].[TblArena_TblActor_TblRoleActancial] CHECK CONSTRAINT [FK_TblArena_TblActor_TblRolActancial_TblRolesActancial]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActors_TblActors]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActors]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActors_TblActors] FOREIGN KEY([idArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActors] CHECK CONSTRAINT [FK_TblArena_TblActors_TblActors]
GO
/****** Object:  ForeignKey [FK_TblArena_TblActors_TblActors1]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblActors]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblActors_TblActors1] FOREIGN KEY([idActor])
REFERENCES [dbo].[TblActors] ([idActor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblActors] CHECK CONSTRAINT [FK_TblArena_TblActors_TblActors1]
GO
/****** Object:  ForeignKey [FK_TblArena_TblObjects_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblObjects]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblObjects_TblArenas] FOREIGN KEY([IdArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblObjects] CHECK CONSTRAINT [FK_TblArena_TblObjects_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblObjects_TblObjects]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblObjects]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblObjects_TblObjects] FOREIGN KEY([IdObj])
REFERENCES [dbo].[TblObjects] ([idObj])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblObjects] CHECK CONSTRAINT [FK_TblArena_TblObjects_TblObjects]
GO
/****** Object:  ForeignKey [FK_TblArena_TblRole_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblRole_TblArenas] FOREIGN KEY([IdArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblRoles] CHECK CONSTRAINT [FK_TblArena_TblRole_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblRole_TblRoles]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblRoles]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblRole_TblRoles] FOREIGN KEY([IdRole])
REFERENCES [dbo].[TblRoles] ([idRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblRoles] CHECK CONSTRAINT [FK_TblArena_TblRole_TblRoles]
GO
/****** Object:  ForeignKey [FK_TblArena_TblRolesActancial_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblRolesActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblRolesActancial_TblArenas] FOREIGN KEY([IdArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblRolesActancial] CHECK CONSTRAINT [FK_TblArena_TblRolesActancial_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblArena_TblRolesActancial_TblRolesActancial]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblArena_TblRolesActancial]  WITH CHECK ADD  CONSTRAINT [FK_TblArena_TblRolesActancial_TblRolesActancial] FOREIGN KEY([IdRoleAct])
REFERENCES [dbo].[TblRolesActancial] ([idRoleAct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblArena_TblRolesActancial] CHECK CONSTRAINT [FK_TblArena_TblRolesActancial_TblRolesActancial]
GO
/****** Object:  ForeignKey [FK_TblScenarios_TblActions1]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblScenarios]  WITH CHECK ADD  CONSTRAINT [FK_TblScenarios_TblActions1] FOREIGN KEY([idAction])
REFERENCES [dbo].[TblActions] ([idAction])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblScenarios] CHECK CONSTRAINT [FK_TblScenarios_TblActions1]
GO
/****** Object:  ForeignKey [FK_TblScenarios_TblArenas]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblScenarios]  WITH CHECK ADD  CONSTRAINT [FK_TblScenarios_TblArenas] FOREIGN KEY([idArena])
REFERENCES [dbo].[TblArenas] ([idArena])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblScenarios] CHECK CONSTRAINT [FK_TblScenarios_TblArenas]
GO
/****** Object:  ForeignKey [FK_TblScenarios_TblScenarios]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblScenarios]  WITH CHECK ADD  CONSTRAINT [FK_TblScenarios_TblScenarios] FOREIGN KEY([idScenario])
REFERENCES [dbo].[TblScenarios] ([idScenario])
GO
ALTER TABLE [dbo].[TblScenarios] CHECK CONSTRAINT [FK_TblScenarios_TblScenarios]
GO
/****** Object:  ForeignKey [FK_TblSentences_TblProcessSentences]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblSentences]  WITH CHECK ADD  CONSTRAINT [FK_TblSentences_TblProcessSentences] FOREIGN KEY([idProcess])
REFERENCES [dbo].[TblProcessSentences] ([idProcess])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSentences] CHECK CONSTRAINT [FK_TblSentences_TblProcessSentences]
GO
/****** Object:  ForeignKey [FK_TblSentences_TblScenarios1]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblSentences]  WITH CHECK ADD  CONSTRAINT [FK_TblSentences_TblScenarios1] FOREIGN KEY([idScenario])
REFERENCES [dbo].[TblScenarios] ([idScenario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSentences] CHECK CONSTRAINT [FK_TblSentences_TblScenarios1]
GO
/****** Object:  ForeignKey [FK_TblSentences_TblTypesSentences]    Script Date: 06/21/2014 09:49:07 ******/
ALTER TABLE [dbo].[TblSentences]  WITH CHECK ADD  CONSTRAINT [FK_TblSentences_TblTypesSentences] FOREIGN KEY([idType])
REFERENCES [dbo].[TblTypesSentences] ([IdType])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSentences] CHECK CONSTRAINT [FK_TblSentences_TblTypesSentences]
GO
