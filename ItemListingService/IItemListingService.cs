using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ItemListingService
{
    [ServiceContract]
    public interface IItemListingService
    {

        [OperationContract]
        List<Item> GetItems(string searchTerm, int page, int pageSize);

    }

    [DataContract]
    public class Item //param for listing
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public double Price { get; set; }
        [DataMember] public string Seller { get; set; }
        [DataMember] public bool IsAvailable { get; set; }
        [DataMember] public string ImageUrl { get; set; }
    }
}
