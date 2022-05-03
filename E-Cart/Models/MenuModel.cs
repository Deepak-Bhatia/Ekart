using System.Collections.Generic;

namespace E_Cart.Models
{
    /// <summary>
    /// This is model class to contain all MenuItem Properties
    /// </summary>
    public class MenuModel
    {
        public string MenuName { get; set; }
        public int MenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<MenuModel> SubMenu { get; set; }
        public int parentId { get; set; }
    }
}
