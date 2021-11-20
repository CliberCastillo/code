CREATE TABLE [dbo].[ProductReviews] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [ProductId] INT            NOT NULL,
    [Title]     NVARCHAR (200) NOT NULL,
    [Review]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProductReviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductReviews_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductReviews_ProductId]
    ON [dbo].[ProductReviews]([ProductId] ASC);

