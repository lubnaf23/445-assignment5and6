using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace SellerAccountService
{
    [ServiceContract]
    public interface ISellerService
    {
        [OperationContract]
        int CreateSeller(string email, string hashedPassword, string name);

        [OperationContract]
        bool UpdateSeller(int sellerId, string newEmail);

        [OperationContract]
        int CreateListing(int sellerId, string itemName, decimal price);
    }

    // Data contracts
    [DataContract]
    public class Seller
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string HashedPassword { get; set; }
        [DataMember] public string Name { get; set; }
    }

    [DataContract]
    public class Listing
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public int SellerId { get; set; }
        [DataMember] public string ItemName { get; set; }
        [DataMember] public decimal Price { get; set; }
    }

    public class SellerService : ISellerService
    {
        private string GetSellerXmlPath()
        {
            return HttpContext.Current.Server.MapPath("~/Seller.xml");
        }

        private string GetListingXmlPath()
        {
            return HttpContext.Current.Server.MapPath("~/Listings.xml");
        }

        public int CreateSeller(string email, string hashedPassword, string name)
        {
            string path = GetSellerXmlPath();
            XDocument doc;

            if (!File.Exists(path))
                doc = new XDocument(new XElement("Sellers"));
            else
                doc = XDocument.Load(path);

            int nextId = doc.Root.Elements("Seller").Count() + 1;

            XElement newSeller = new XElement("Seller",
                new XElement("Id", nextId),
                new XElement("Email", email),
                new XElement("HashedPassword", hashedPassword),
                new XElement("Name", name)
            );

            doc.Root.Add(newSeller);
            doc.Save(path);

            return nextId;
        }

        public bool UpdateSeller(int sellerId, string newEmail)
        {
            string path = GetSellerXmlPath();
            if (!File.Exists(path)) return false;

            XDocument doc = XDocument.Load(path);
            var seller = doc.Root.Elements("Seller")
                .FirstOrDefault(s => (int)s.Element("Id") == sellerId);

            if (seller == null) return false;

            seller.Element("Email").Value = newEmail;
            doc.Save(path);

            return true;
        }

        public int CreateListing(int sellerId, string itemName, decimal price)
        {
            string sellersPath = GetSellerXmlPath();
            string listingsPath = GetListingXmlPath();

            if (!File.Exists(sellersPath))
                return -1; // No sellers created yet

            // Load sellers
            XDocument sellersDoc = XDocument.Load(sellersPath);

            bool sellerExists = sellersDoc.Root.Elements("Seller")
                .Any(s => (int)s.Element("Id") == sellerId);

            if (!sellerExists)
                return -1;

            // Load or create Listings.xml
            XDocument listingsDoc;
            if (!File.Exists(listingsPath))
                listingsDoc = new XDocument(new XElement("Listings"));
            else
                listingsDoc = XDocument.Load(listingsPath);

            int nextListingId = listingsDoc.Root.Elements("Listing").Count() + 1;

            XElement newListing = new XElement("Listing",
                new XElement("Id", nextListingId),
                new XElement("SellerId", sellerId),
                new XElement("ItemName", itemName),
                new XElement("Price", price),
                new XElement("Description", "Added via SellerService"),
                new XElement("Seller", "seller" + sellerId),
                new XElement("IsAvailable", true),
                new XElement("ImageUrl", "~/Images/placeholder.png")
            );

            listingsDoc.Root.Add(newListing);
            listingsDoc.Save(listingsPath);

            return nextListingId;
        }
    }
}
