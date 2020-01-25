CREATE TABLE [dbo].[Event]
(
	[EventId] INT IDENTITY (1, 1) NOT NULL,
	[EventName] NVarChar(2000) Not NULL,
	[Inserted_By] UniqueIdentifier Not Null,
	[Inserted_Date] DATETIME Not Null
)
