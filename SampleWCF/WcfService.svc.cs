﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleWCF
{
    public class WcfService : IWcfService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Echo(string echoWord)
        {
            return $"The word you said with GET is: {echoWord}";
        }

        public string EchoXml(string echoWord)
        {
            return $"The word you said with GET is: {echoWord}";
        }
    }
}
