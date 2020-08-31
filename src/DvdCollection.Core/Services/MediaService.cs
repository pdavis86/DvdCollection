using DvdCollection.Core.Models.Operation;
using DvdCollection.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DvdCollection.Core.Services
{
    public class MediaService : IService
    {
        private readonly BlobStorageService _blobStorageService;
        private readonly string _containerName;
        private readonly Data.Context _ctx;
        private readonly OmdbService _omdbService;

        public MediaService(
            BlobStorageService blobStorageService,
            string containerName,
            OmdbService omdbService
        )
        {
            _blobStorageService = blobStorageService;
            _containerName = containerName;
            _ctx = new Data.Context();
            _omdbService = omdbService;
        }

        public async Task<Result<bool>> AddAsync(string filePath, string imdbId = null)
        {
            try
            {
                var newFileEntity = _ctx.Add(new MediaFile
                {
                    Name = Path.GetFileName(filePath)
                });

                await _ctx.SaveChangesAsync();

                var uploadResult = await _blobStorageService.UploadAsync(filePath, _containerName, newFileEntity.Entity.Id.ToString());

                if (!uploadResult.IsSuccess)
                {
                    return new Result<bool>(uploadResult.Exception, uploadResult.Message);
                }

                if (!string.IsNullOrWhiteSpace(imdbId))
                {
                    await FillMediaDetails(newFileEntity.Entity.Id, imdbId);
                }

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        private async Task<bool> FillMediaDetails(Guid mediaFileId, string imdbId)
        {
            var movie = await _omdbService.GetAsync(imdbId);

            var details = new Dictionary<string, string>
            {
                { Constants.MediaDetails.Keys.Title, movie.Title },
                //{ "", movie.Genre },
                //{ "", movie.ImdbRating },
                //{ "", movie.ImdbVotes },
                //{ "", movie.MetaScore },
                //{ "", movie.Poster },
                //{ "", movie.Rated },
                //{ "", movie.Released },
                //{ "", movie.Runtime },
                //{ "", movie.Type },
                //{ "", movie.Year },
            };

            Parallel.ForEach(details, x =>
                _ctx.Add(new MediaDetails
                {
                    MediaFileId = mediaFileId,
                    Key = x.Key,
                    Value = x.Value
                })
            );

            await _ctx.SaveChangesAsync();

            return true;
        }

    }
}
