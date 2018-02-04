using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class WcfCommunicationClient : ServicePartitionClient<WcfCommunicationClient<IHelloContract>>
    {
        public WcfCommunicationClient(ICommunicationClientFactory<WcfCommunicationClient<IHelloContract>> communicationClientFactory,
                                      Uri serviceUri,
                                      ServicePartitionKey partitionKey = null,
                                      TargetReplicaSelector targetReplicaSelector = TargetReplicaSelector.Default,
                                      string listenerName = null,
                                      OperationRetrySettings retrySettings = null)
            : base(communicationClientFactory, serviceUri, partitionKey, targetReplicaSelector, listenerName, retrySettings)
        {
        }
    }
}