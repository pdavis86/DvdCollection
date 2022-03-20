using DvdCollection.Core.Models.Operation;
using DvdCollection.Data.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DvdCollection.Core.Services
{
    public class MediaService : IService
    {
        private readonly Data.Context _ctx;
        private readonly OmdbService _omdbService;

        public MediaService(
            Data.Context ctx,
            OmdbService omdbService
        )
        {
            _ctx = ctx;
            _omdbService = omdbService;
        }

        public async Task<Result<bool>> AddAsync(string filePath, string imdbId = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imdbId))
                {
                    var movie = await _omdbService.GetAsync(imdbId);

                    _ctx.Add(new MediaFile
                    {
                        FileName = Path.GetFileName(filePath),
                        ImdbId = imdbId,
                        Title = movie.Title,
                        Genre = movie.Genre,
                        PosterUrl = movie.Poster,
                        ReleaseDate = DateTime.Parse(movie.Released),
                        RuntimeMinutes = movie.Runtime != "N/A" ? int.Parse(movie.Runtime.Replace(" min", null)) : (int?)null,
                        ReleaseYear = int.Parse(movie.Year)
                    });
                }
                else
                {
                    _ctx.Add(new MediaFile
                    {
                        FileName = Path.GetFileName(filePath)
                    });
                }

                return new Result<bool>(await _ctx.SaveChangesAsync() == 1);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

    }
}
