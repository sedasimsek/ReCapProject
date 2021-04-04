CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT          IDENTITY (1, 1) NOT NULL,
    [UserId]      INT          NOT NULL,
    [CompanyName] VARCHAR (50) NOT NULL,
    [FindexScore] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

