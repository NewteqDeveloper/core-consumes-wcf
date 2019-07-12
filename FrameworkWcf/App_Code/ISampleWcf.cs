using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

    [ServiceContract]
    public interface ISampleWcf
    {
        [OperationContract]
        [WebGet(UriTemplate = "echo/{word}", ResponseFormat = WebMessageFormat.Json)]
        string EchoJson(string word);

        [OperationContract]
        [WebGet(UriTemplate = "echo2/{word}")]
        string EchoXml(string word);

        [OperationContract]
        [WebInvoke(UriTemplate = "complexEcho")]
        ComplexEchoResponse Echo(ComplexEchoInput input);
    }

    [DataContract]
    public class ComplexEchoInput
    {
        [DataMember]
        public string Word { get; set; }
    }

    [DataContract]
    public class ComplexEchoResponse
    {
        [DataMember]
        public string Response { get; set; }
    }