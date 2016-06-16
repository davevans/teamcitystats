CREATE TABLE [dbo].[Statistic]
(
	[Id]			BIGINT IDENTITY(1,1)			NOT NULL,
	[Timestamp]		DATETIME						NOT NULL CONSTRAINT DC_Statistic_Timestamp DEFAULT GETDATE(),
	[Key]			VARCHAR(255)					NOT NULL,
	[Value]			VARCHAR(1024)					NOT NULL,
	[BuildId]		VARCHAR(255)					NOT NULL,
	[BuildNumber]	VARCHAR(255)					NOT NULL,

	CONSTRAINT PK_Statistic_Id PRIMARY KEY CLUSTERED (Id)
)
