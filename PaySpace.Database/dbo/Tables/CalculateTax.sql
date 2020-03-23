CREATE TABLE [dbo].[CalculateTax] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [TaxAmount]    DECIMAL (18, 2) NOT NULL,
    [Income]       DECIMAL (18, 2) NOT NULL,
    [PostalCode]   INT             NOT NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [ModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_CalculateTax] PRIMARY KEY CLUSTERED ([Id] ASC)
);

