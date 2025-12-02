using System;
using System.Collections.Generic;
using System.Runtime.Serialization; //DataContract
using System.ServiceModel;

namespace SellerAccountService  //used for new client as well
{
    [ServiceContract]  //metadata
    public interface ISellerService
    {
        [OperationContract] 
        int CreateSeller(string email, string hashedPassword, string name);

        [OperationContract]
        bool UpdateSeller(int sellerId, string newEmail);

        [OperationContract]
        int CreateListing(int sellerId, string itemName, decimal price);
    }

    //returning  later
    [DataContract]  //wcf
    public class Seller
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string HashedPassword { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Listing
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SellerId { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }

    public class SellerService : ISellerService  //fully contracted
    {
        //mem
        private static Dictionary<int, Seller> sellers = new Dictionary<int, Seller>();
        private static Dictionary<int, Listing> listings = new Dictionary<int, Listing>();
        //private static Dictionary<int, List<int>> updtListings = new Dictionary<int, List<int>>();
        private static int nextSellerId = 1, nextListingId = 1;


        public int CreateSeller(string email, string hashedPassword, string name)
        {
            if (string.IsNullOrEmpty(email)) return -1;
            int id = nextSellerId++;
            sellers[id] = new Seller { Id = id, Email = email, HashedPassword = hashedPassword, Name = name };
            return id;
        }

        public bool UpdateSeller(int sellerId, string newEmail) //fixed 
        {
            if (sellers.ContainsKey(sellerId) && !string.IsNullOrEmpty(newEmail))
            {
                sellers[sellerId].Email = newEmail;
                return true;
            }
            return false;
        }

    //figure out update listing
        public int CreateListing(int sellerId, string itemName, decimal price)
        {
            if (!sellers.ContainsKey(sellerId) || string.IsNullOrEmpty(itemName)) return -1;
            int id = nextListingId++;
            listings[id] = new Listing { Id = id, SellerId = sellerId, ItemName = itemName, Price = price };
            return id;
        }
    }
}