using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class SampleWcf : ISampleWcf
{
    public ComplexEchoResponse Echo(ComplexEchoInput input)
    {
        return new ComplexEchoResponse
        {
            Response = string.Format("Your complex input value :: {0}", input.Word)
        };
    }

    public string EchoJson(string word)
    {
        return string.Format("You requested JSON for this word :: {0}", word);
    }

    public string EchoXml(string word)
    {
        return string.Format("You requested XML for this word :: {0}", word);
    }
}
