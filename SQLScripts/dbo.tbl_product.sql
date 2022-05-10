USE [ekart]
GO

/****** Object: Table [dbo].[tbl_product] Script Date: 5/10/2022 8:23:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_product] (
    [Product_id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Product_Name]               VARCHAR (100) NULL,
    [Product_Description]        VARCHAR (100) NULL,
    [Product_Available_Quantity] INT           NULL,
    [Product_Available_Colors ]  VARCHAR (100) NULL,
    [Product_Category_Id]        INT           NULL,
    [Product_Company_Id]         INT           NULL,
    [Product_Price]              INT           NULL,
    [Url]                        VARCHAR (100) NULL,
    [Product_Popularity]         INT           NULL,
    [Available_Size]             VARCHAR (200) NULL
);


