CREATE TYPE [dbo].[MovieActors] AS TABLE (
    [Id]    BIGINT NULL,
    [Movie] BIGINT NOT NULL,
    [Actor] BIGINT NOT NULL);

