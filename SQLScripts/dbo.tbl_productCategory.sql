USE [ekart]
GO

/****** Object: Table [dbo].[tbl_productCategory] Script Date: 5/10/2022 8:23:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_productCategory] (
    [Category_id]   INT           IDENTITY (1, 1) NOT NULL,
    [Category_Name] VARCHAR (100) NULL
);


