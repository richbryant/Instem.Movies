CREATE TABLE [dbo].[MovieActors] (
    [Id]    BIGINT IDENTITY (1, 1) NOT NULL,
    [Movie] BIGINT NOT NULL,
    [Actor] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

