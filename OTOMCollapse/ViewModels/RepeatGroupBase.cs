using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace OTOMCollapse.ViewModels
{
    [Serializable]
    [DataContract]
    public abstract class RepeatGroupBase
    {
        [XmlAttribute("id")]
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }
       
    }
}
