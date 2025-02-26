using Vidsnap.Common.Dto.Api;
using Vidsnap.Common.Dto.DataSource;

namespace Vidsnap.Core.Interfaces;

public interface IVideoUploaderController
{
    Task<ResultadoOperacao<VideoDto>> CadastrarNovoVideo(VideoSemIdDto novoVideo);
}