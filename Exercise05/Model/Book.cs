using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05.Model
{
    [DataContract]
    public class Book
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "cat")]
        public List<string> Category { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "series_t")]
        public string Series { get; set; }

        [DataMember(Name = "sequence_i")]
        public int Sequence { get; set; }

        [DataMember(Name = "genre_s")]
        public string Genre { get; set; }

        [DataMember(Name = "inStock")]
        public bool InStock { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "pages_i")]
        public int Pages { get; set; }
    }
}
