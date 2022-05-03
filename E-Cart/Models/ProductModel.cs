using System.Collections.Generic;

namespace E_Cart.Models
{
    /// <summary>
    /// This model class contains all properties related to a Product
    /// </summary>
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public float Price { get; set; }
        public int Popularity { get; set; }
        public List<string> AvailableSize { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public List<string>  AvailableColors { get; set; }
        public string Url { get; set; }


    }
}
