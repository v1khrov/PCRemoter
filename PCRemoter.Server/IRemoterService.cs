using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PCRemoter.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRemoterService" in both code and config file together.
    [ServiceContract]
    public interface IRemoterService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string Hello();

        [OperationContract]
        string Echo(string _message);

        [OperationContract]
        string TestConnection();

        [OperationContract]
        string Controls(string _buttonName);
    }
}
