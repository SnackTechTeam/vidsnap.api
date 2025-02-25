using vidsnap.common.Dto.Api;
using vidsnap.common.Dto.DataSource;

namespace vidsnap.core.Interfaces;

public interface IVideoUploaderController
{
    Task<ResultadoOperacao<VideoDto>> CadastrarNovoVideo(VideoSemIdDto novoVideo);
}