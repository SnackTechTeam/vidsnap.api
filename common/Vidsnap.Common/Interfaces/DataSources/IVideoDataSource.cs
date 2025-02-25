using vidsnap.common.Dto.DataSource;

namespace vidsnap.common.Interfaces.DataSources;

public interface IVideoDataSource
{
    Task<bool> InserirVideoAsync(VideoDto videoNovo);
}