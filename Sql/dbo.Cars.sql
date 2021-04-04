CREATE TABLE [dbo].[Cars] (
    [CarId]       INT          IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT          NOT NULL,
    [ColorId]     INT          NOT NULL,
    [ModelYear]   VARCHAR (50) NOT NULL,
    [DailyPrice]  DECIMAL (18) NOT NULL,
    [Description] VARCHAR (50) NOT NULL,
    [MinFindexScore] INT NULL, 
    PRIMARY KEY CLUSTERED ([CarId] ASC)
);

