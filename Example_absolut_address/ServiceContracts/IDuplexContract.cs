using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    [ServiceContract(CallbackContract = typeof(IDuplexCallback))]
    public interface IDuplexContract
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        string HelloFormService();
    }

    public interface IDuplexCallback
    {
        [OperationContract(IsOneWay = false)]
        string HelloFromClient();
    }
}
