using Vidsnap.Common.Dto.DataSource;
using Vidsnap.Common.Interfaces.DataSources;
using Vidsnap.Database.Context;
using Vidsnap.Database.Entities;
using Vidsnap.Database.Util;

namespace Vidsnap.Database.DataSources;

public class VideoDataSource(RepositoryDbContext repositoryDbContext) : IVideoDataSource
{
    private readonly RepositoryDbContext _repositoryDbContext = repositoryDbContext;

    public async Task<bool> InserirVideoAsync(VideoDto videoNovo)
    {
        var videoEntity = Mapping.Mapper.Map<Video>(videoNovo);
        _repositoryDbContext.Add(videoEntity);
        var resultado = await _repositoryDbContext.SaveChangesAsync();

        return resultado > 0;
    }
}