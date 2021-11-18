using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Project2_Images.Models
{
    public class Image
    {

        public int ID { get; set; }

        public string FileName { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Uploader { get; set; }
        
        [Display(Name = "Captured by")]
        public string CapturedBy { get; set; }

        public string GeoTag { get; set; }

        public string Tags { get; set; }
        
        [Display(Name = "Image File")]
        [DataType(DataType.Upload)]
        public byte[] AdvertisementAsset { get; set; }

    }
}
