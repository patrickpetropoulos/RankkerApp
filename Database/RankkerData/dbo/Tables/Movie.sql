CREATE TABLE [dbo].[Movie]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Tagline] NVARCHAR(MAX) NOT NULL, 
    [Overview] NVARCHAR(MAX) NOT NULL, 
    [ReleaseDate] DATETIME2 NULL, 
    [Runtime] INT NULL, 
    [Budget] BIGINT NULL, 
    [Revenue] BIGINT NULL, 
    [TmdbId] BIGINT NOT NULL, 
    [ImdbId] NVARCHAR(50) NULL, 
    [TmdbPosterPath] NVARCHAR(500) NOT NULL, 
    [TmdbBackdropPath] NVARCHAR(500) NOT NULL, 
    [Status] NVARCHAR(50) NULL, 
    [DateUpdated] DATETIME2 NULL,
)
