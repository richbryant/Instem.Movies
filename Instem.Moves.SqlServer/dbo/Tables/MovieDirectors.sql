CREATE TABLE [dbo].[MovieDirectors] (
    [Id]       BIGINT IDENTITY (1, 1) NOT NULL,
    [Movie]    BIGINT NOT NULL,
    [Director] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

