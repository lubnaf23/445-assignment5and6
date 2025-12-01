using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ItemListingService
{
    public class ItemListingService : IItemListingService
    {
        private static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name="Laptop", Description="Laptop", Price=999, Seller="seller1", IsAvailable=true, ImageUrl = "~/Images/laptop.jpg" },
            new Item { Id = 2, Name="Keyboard", Description="Mechanical keyboard", Price=89, Seller="seller2", IsAvailable=true, ImageUrl = "~/Images/keyboard.jpg" },
            new Item { Id = 3, Name="Mouse", Description="Wireless mouse", Price=29, Seller="seller2", IsAvailable=true, ImageUrl = "~/Images/mouse.jpg" },
            new Item { Id = 4, Name="Monitor", Description="24-inch monitor", Price=149, Seller="seller1", IsAvailable=true, ImageUrl = "~/Images/monitor.jpg" }
        };

        public List<Item> GetItems(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            IEnumerable<Item> result = items;

            // Optional search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                result = result.Where(i => i.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                i.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // Pagination
            result = result.Skip((page - 1) * pageSize).Take(pageSize);

            return result.ToList();
        }
    }
}
