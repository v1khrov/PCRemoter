using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PCRemoter.Web
{
	public struct PCRemoteMessages
	{
		public string _message;
	}
    /// <summary>
    /// Summary description for PCRemoterService
    /// </summary>
    [WebService(Namespace = "http://itfi.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]



    public class PCRemoterService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


		[WebMethod]
		public PCRemoteMessages Echo(PCRemoteMessages _remoteMessage)
		{
			PCRemoteMessages _prm = new PCRemoteMessages();

			_prm._message = _remoteMessage._message;

			return _prm;
		}
    }

}
