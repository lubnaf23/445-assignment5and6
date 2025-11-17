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
        // Returns a list of buyer IDs
        List<int> getBuyers();

        [OperationContract]
        String getBuyerName(int id);

        [OperationContract]
        int addBuyer(String name);
    }
}
