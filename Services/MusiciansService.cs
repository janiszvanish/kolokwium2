using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Services
{
    public class MusiciansService : IMusiciansService
    {
        private readonly KolokwiumDbContext _context;
        public MusiciansService(KolokwiumDbContext context){
            _context = context;
        }
        
        public async Task<Album> GetAlbumByIdAsync(int albumId){
            var album = await _context.Albums.Where(e => e.IdAlbum == albumId).FirstOrDefaultAsync();
            if(album is null)
                return null;
            
            return album;
        } 

        public async Task<bool> DeleteMusician(Musician musician){
            if(! await CheckIfMusicianExistAsync(musician.IdMusician))
                return false;
            if()
        }

        private async Task<bool> CheckIfMusicianCreatesAlbums(Musician musician){
            var m = await _context.Musicians.Where(e => e.IdMusician == musician.IdMusician).FirstOrDefaultAsync();
            if(m is null)
                return false;
            
            var mtracks = m.MusicianTracks;

            if(mtracks is null)
                return false;
            
            for(MusicianTrack mt in mtracks)
            {
                
            }
            
        }

        private async Task<bool> CheckIfMusicianExistAsync(int id){
            var musician = await _context.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
            if(musician is null)
                return false;
            else
                return true;
        }


    }
}