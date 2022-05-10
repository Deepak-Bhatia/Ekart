USE [ekart]
GO

/****** Object: Table [dbo].[tbl_productCompany] Script Date: 5/10/2022 8:23:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_productCompany] (
    [Company_id]   INT           IDENTITY (1, 1) NOT NULL,
    [Company_Name] VARCHAR (100) NULL
);


