CREATE TABLE [dbo].[Movies] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (255) NULL,
    [Year]        INT            NULL,
    [ReleaseDate] DATETIME       NULL,
    [Rating]      DECIMAL (18)   NULL,
    [ImageUrl]    NVARCHAR (255) NULL,
    [Plot]        NVARCHAR (MAX) NULL,
    [Rank]        INT            NULL,
    [RunningTime] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

