using E_Cart.Models;
using E_Cart.Utility;
using System;
using System.Collections.Generic;
using System.Data;

namespace E_Cart.DBLayer
{

    /// <summary>
    /// This  class contains method to access product data from DB
    /// </summary>
    public class ProductDB
    {
        private String connectionString;
        public ProductDB(String connectionString) {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// This method returns all products from DB
        /// </summary>
        /// <returns>List of ProductModel</returns>
        public List<ProductModel> getProducts() {

            DataTable dt = new DBUtil(connectionString).CallStoredProcedure("GetAllProducts");
            List<ProductModel> products = new List<ProductModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ProductModel product = new ProductModel();
                product.ProductId = Convert.ToInt32(dr["Product_id"].ToString());
                product.Name = dr["Product_Name"].ToString();
                product.Description = dr["Product_Description"].ToString();
                product.AvailableQuantity = Convert.ToInt32(dr["Product_Available_Quantity"].ToString());
                product.AvailableColors =  String.IsNullOrEmpty(dr["Product_Available_Colors "].ToString()) ? null : new List<string>(dr["Product_Available_Colors "].ToString().Split(","));
                product.AvailableSize =  String.IsNullOrEmpty(dr["Available_Size"].ToString()) ? null : new List<string>(dr["Available_Size"].ToString().Split(","));
                product.CategoryId = Convert.ToInt32(dr["Product_Category_Id"].ToString());
                product.CompanyId = Convert.ToInt32(dr["Product_Company_Id"].ToString());
                product.CategoryName = dr["Category_Name"].ToString();
                product.CompanyName = dr["Company_Name"].ToString();
                product.Price = Convert.ToInt32(dr["Product_Price"].ToString());
                product.Popularity = Convert.ToInt32(dr["Product_Popularity"].ToString());
                product.Url = dr["Url"].ToString();
                products.Add(product);
            }
            return products;
        }

    }
}
