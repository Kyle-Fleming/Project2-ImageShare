using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Images.Models;
using Project2_Images.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imagesRepository;
        public ImagesController(IImageRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Image>> GetImages()
        {
            return await _imagesRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImages(int id)
        {
            return await _imagesRepository.Get(id);
        }
    }
}
