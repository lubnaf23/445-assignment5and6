using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BuyerService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        // Returns a list of buyer information
        List<Buyer> getBuyers();

        [OperationContract]
        string getBuyerName(string email);

        [OperationContract]
        bool addBuyer(string email, string hashedPw, string name);
    }

    [DataContract]
    public class Buyer
    {
        [DataMember]
        public String Email { get; set; }

        [DataMember]
        public string HashedPw { get; set; }

        [DataMember]
        public String Name { get; set; }
    }
}
