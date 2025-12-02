using System.ServiceModel;
using System.Runtime.Serialization; // For data contracts

[ServiceContract]
public interface ISellerService
{
    [OperationContract]
    int CreateSeller(string email, string hashedPassword, string name);
    [OperationContract]
    bool UpdateSeller(int sellerId, string newEmail);
    [OperationContract]
    int CreateListing(int sellerId, string itemName, decimal price);
    //[OperationContract]
    //bool UpdateListing(int sellerId, string iteName, decimal newPrice);
    
}

[DataContract]
public class Seller { [DataMember] public int Id { get; set; } [DataMember] public string Email { get; set; } [DataMember] public string HashedPassword { get; set; } [DataMember] public string Name { get; set; } }
[DataContract]
public class Listing { [DataMember] public int Id { get; set; } [DataMember] public int SellerId { get; set; } [DataMember] public string ItemName { get; set; } [DataMember] public decimal Price { get; set; } }