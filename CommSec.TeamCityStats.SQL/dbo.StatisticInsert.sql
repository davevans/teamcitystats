CREATE PROCEDURE [dbo].[StatisticInsert]
	@Key			VARCHAR(255),
	@Value			VARCHAR(1024),
	@BuildId		VARCHAR(255),
	@BuildNumber	VARCHAR(255),
	@Id				BIGINT OUTPUT
AS
	INSERT INTO Statistic([Key], [Value], [BuildId], [BuildNumber])
	VALUES
	(
		@Key,
		@Value,
		@BuildId,
		@BuildNumber
	)

	SET @Id = SCOPE_IDENTITY()
RETURN 0
