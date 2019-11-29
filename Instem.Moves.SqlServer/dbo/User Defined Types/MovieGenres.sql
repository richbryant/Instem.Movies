CREATE TYPE [dbo].[MovieGenres] AS TABLE (
    [Id]    BIGINT NULL,
    [Movie] BIGINT NOT NULL,
    [Genre] BIGINT NOT NULL);

