using Vidsnap.Common.Dto.DataSource;

namespace Vidsnap.Common.Interfaces.DataSources;

public interface IVideoDataSource
{
    Task<bool> InserirVideoAsync(VideoDto videoNovo);
}