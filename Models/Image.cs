using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class Image
    {

        public int ID { get; set; }
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public int Uploader { get; set; }
        public string GeoTag { get; set; }

        public string FileType { get; set; }

        



    }
}
