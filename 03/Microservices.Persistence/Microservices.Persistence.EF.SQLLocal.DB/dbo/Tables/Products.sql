CREATE TABLE [dbo].[Products] (
    [Id]            INT                IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)     NOT NULL,
    [Type]          INT                NOT NULL,
    [Description]   NVARCHAR (MAX)     NOT NULL,
    [Price]         DECIMAL (18, 2)    NOT NULL,
    [Stock]         INT                NOT NULL,
    [Rating]        INT                NOT NULL,
    [IntroducedAt]  DATETIMEOFFSET (7) NOT NULL,
    [PhotoFileName] NVARCHAR (100)     NULL,
    [CustomField]   NCHAR (10)         NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

