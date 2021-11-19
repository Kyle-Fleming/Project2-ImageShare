using Microsoft.AspNetCore.Http;
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

        [Display(Name ="User to share with (optional)")]
        public string OwnerID { get; set; }
        
        [Display(Name = "File name")]
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

        //public IFormFile Picture { get; set; }
    }
}
