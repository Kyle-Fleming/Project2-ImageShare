using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Project2_Images.Data;
using Project2_Images.Models;


namespace Project2_Images.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly Project2_ImagesContext _context;
        public IConfiguration _configuration;

        //static declaration of CloudBlobClient to interact with the service
        static CloudBlobClient BlobClient;

        //constant to hold the container name
        const string IMAGE_BLOB = "project2imagestorage";

        //static declaration to storage reference to blobcontainer
        static CloudBlobContainer BlobContainer;

        [BindProperty]
        public Image Image { get; set; }

        public CreateModel(IConfiguration configuration, Project2_ImagesContext context)
        {
            _configuration = configuration;
            _context = context;
        }

      

        public async Task<IActionResult> OnGetAsync()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("AzureStorageConnectionString"));
            BlobClient = storageAccount.CreateCloudBlobClient();
            BlobContainer = BlobClient.GetContainerReference(IMAGE_BLOB);
            await BlobContainer.CreateIfNotExistsAsync();
            await BlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob }); 
            return Page();
        }        

        
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                /*
                var filestoup = formFiles.GetFile("advertisementAsset");
                //fix this because the image is not stored in "Files"
                //var file = form.Files[0];

                CloudBlockBlob blob = BlobContainer.GetBlockBlobReference(filestoup?.FileName);
                blob.Properties.ContentType = filestoup?.ContentType;
                await blob.UploadFromStreamAsync(filestoup.OpenReadStream());
                Image.URL = $"{BlobContainer.StorageUri.PrimaryUri}/{filestoup?.FileName}";
                */
                _context.Image.Add(Image);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Image upload success";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
