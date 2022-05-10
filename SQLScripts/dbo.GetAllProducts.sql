USE [ekart]
GO

/****** Object: SqlProcedure [dbo].[GetAllProducts] Script Date: 5/10/2022 8:24:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAllProducts
AS

 SELECT * FROM tbl_product p INNER JOIN  tbl_productCategory pc on p.Product_Category_Id = pc .Category_id
							INNER JOIN  tbl_productCompany pcompany on  p.Product_Company_Id= pcompany.Company_id
