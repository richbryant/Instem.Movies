CREATE TABLE [dbo].[MovieGenres] (
    [Id]    BIGINT IDENTITY (1, 1) NOT NULL,
    [Movie] BIGINT NOT NULL,
    [Genre] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

