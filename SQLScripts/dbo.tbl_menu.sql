USE [ekart]
GO

/****** Object: Table [dbo].[tbl_menu] Script Date: 5/10/2022 8:23:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_menu] (
    [Menu_id]        INT           IDENTITY (1, 1) NOT NULL,
    [Menu_Name]      VARCHAR (100) NULL,
    [Controller]     VARCHAR (100) NULL,
    [Action]         VARCHAR (100) NULL,
    [Parent_menu_id] INT           NULL
);


