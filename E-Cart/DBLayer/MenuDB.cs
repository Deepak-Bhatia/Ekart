using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using E_Cart.Models;
using Microsoft.Extensions.Configuration;
using E_Cart.Utility;

namespace E_Cart.DBLayer
{

    /// <summary>
    /// This  class contains method to access Dynamic Menu data from DB
    /// </summary>
    public class MenuDB
    {
        private string connectionString;


        public MenuDB( String  connectionString )
        {
           this.connectionString = connectionString;
        }


        /// <summary>
        /// This method returns the dynamic menu from database.
        /// </summary>
        /// <returns>List of MenuModel</returns>
        public List<MenuModel> getMenu()
        {

            DataTable dt = new DBUtil(connectionString).CallStoredProcedure("GetAllMenuItems");

            List<MenuModel> menuModels = new List<MenuModel>();
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel tempMenu = new MenuModel();
                tempMenu.MenuId =   Convert.ToInt32( dr["Menu_id"].ToString() );
                tempMenu.MenuName = dr["Menu_Name"].ToString();
                tempMenu.ControllerName = dr["Controller"].ToString();
                tempMenu.ActionName = dr["Action"].ToString();
                tempMenu.parentId = Convert.ToInt32(dr["Parent_menu_id"].ToString());
                menuModels.Add(tempMenu);
            }


            List<MenuModel> menu = menuModels.Where(x => x.parentId == 0).ToList();
            //Map the submenu based on parent id
            foreach (MenuModel tempMenu in menu) {
                if (menuModels.Any(x => x.parentId == tempMenu.MenuId)) {
                    if (tempMenu.SubMenu == null)
                        tempMenu.SubMenu = new List<MenuModel>();
                     tempMenu.SubMenu.AddRange(menuModels.Where(x => x.parentId == tempMenu.MenuId).ToList());
                }
            }
            return menu;
        }

      





    }
}
