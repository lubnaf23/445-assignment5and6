using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace ItemListingService
{
    public class ItemListingService : IItemListingService
    {
        private readonly string listingsPath =
        HttpContext.Current.Server.MapPath("~/Listings.xml");

        public List<Item> GetItems(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            List<Item> items = LoadItems();

            // Optional search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                items = items.Where(i =>
                    i.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    i.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            // Pagination
            return items.Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        // Helper: Reads Listings.xml and loads into Item objects
        private List<Item> LoadItems()
        {
            List<Item> list = new List<Item>();

            XDocument doc = XDocument.Load(listingsPath);
            foreach (var node in doc.Root.Elements("Listing"))
            {
                list.Add(new Item
                {
                    Id = (int)node.Element("Id"),
                    Name = (string)node.Element("Name"),
                    Description = (string)node.Element("Description"),
                    Price = (double)node.Element("Price"),
                    Seller = (string)node.Element("Seller"),
                    IsAvailable = (bool)node.Element("IsAvailable"),
                    ImageUrl = (string)node.Element("ImageUrl")
                });
            }

            return list;
        }
    }
}
