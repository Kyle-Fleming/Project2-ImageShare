using Project2_Images.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> Get();
        Task<Image> Get(int id);
        Task<Image> Create(Image image);
        Task Update(Image image);
        Task Delete(int id);
    }
}
