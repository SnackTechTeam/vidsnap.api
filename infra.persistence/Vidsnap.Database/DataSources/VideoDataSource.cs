using vidsnap.common.Dto.DataSource;
using vidsnap.common.Interfaces.DataSources;
using vidsnap.database.Context;
using vidsnap.database.Entities;
using vidsnap.database.Util;

namespace vidsnap.database.DataSources;

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