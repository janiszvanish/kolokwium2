using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;

namespace kolokwium.Services
{
    public interface IMusiciansService
    {
        public Task<Album> GetAlbumByIdAsync(int albumId);
        public Task<bool> DeleteMusician(Musician musician);
    }
}