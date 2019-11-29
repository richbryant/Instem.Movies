CREATE TYPE [dbo].[MovieDirectors] AS TABLE (
    [Id]       BIGINT NULL,
    [Movie]    BIGINT NOT NULL,
    [Director] BIGINT NOT NULL);

