using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Exercise06.Model
{
    [XmlRoot(ElementName = "catalog")]
    public class Catalog
    {
        [XmlElement(ElementName = "book")]
        public List<Book> Book { get; set; }
    }
}
