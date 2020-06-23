CREATE TABLE [dbo].[MovieGenre]
(
    [Name] NVARCHAR(50) NOT NULL, 
    [Id] INT PRIMARY KEY NOT NULL,
	CONSTRAINT [moviegenre_namesourceid] UNIQUE NONCLUSTERED (
		[Name], [Id]
	)
)

