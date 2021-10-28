using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class Image
    {

        public int ID { get; set; }

        public string FileName { get; set; }

        [Display(Name ="Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        //TODO:  public int Uploader { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Uploader { get; set; }

        public string GeoTag { get; set; }

        public string FileType { get; set; }
    }
}
