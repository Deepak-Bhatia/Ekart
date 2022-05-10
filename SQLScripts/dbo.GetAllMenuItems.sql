USE [ekart]
GO

/****** Object: SqlProcedure [dbo].[GetAllMenuItems] Script Date: 5/10/2022 8:24:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAllMenuItems
AS

 Select * from tbl_menu
