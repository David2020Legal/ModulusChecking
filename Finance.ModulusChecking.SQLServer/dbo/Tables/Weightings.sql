CREATE TABLE [dbo].[Weightings] (
    [ID]               INT          IDENTITY (1, 1) NOT NULL,
    [SortCodeFrom]     NCHAR (6)    NOT NULL,
    [SortCodeTo]       NCHAR (6)    NOT NULL,
    [Method]           NCHAR (5)    NOT NULL,
    [WeightingDigit1]  INT          NOT NULL,
    [WeightingDigit2]  INT          NOT NULL,
    [WeightingDigit3]  INT          NOT NULL,
    [WeightingDigit4]  INT          NOT NULL,
    [WeightingDigit5]  INT          NOT NULL,
    [WeightingDigit6]  INT          NOT NULL,
    [WeightingDigit7]  INT          NOT NULL,
    [WeightingDigit8]  INT          NOT NULL,
    [WeightingDigit9]  INT          NOT NULL,
    [WeightingDigit10] INT          NOT NULL,
    [WeightingDigit11] INT          NOT NULL,
    [WeightingDigit12] INT          NOT NULL,
    [WeightingDigit13] INT          NOT NULL,
    [WeightingDigit14] INT          NOT NULL,
    [Exception]        NVARCHAR (8) NULL,
    CONSTRAINT [PK_Weightings] PRIMARY KEY CLUSTERED ([ID] ASC)
);

