using Microsoft.EntityFrameworkCore;
using Project2_Images.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ImageContext _context;

        public ImageRepository(ImageContext context)
        {
            _context = context;
        }

        public async Task<Image> Create(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task Delete(int id)
        {
            var ImageToDelete = await _context.Images.FindAsync(id);
            _context.Images.Remove(ImageToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> Get()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> Get(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task Update(Image image)
        {
            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
