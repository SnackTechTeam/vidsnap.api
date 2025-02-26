using Vidsnap.Common.Dto.Api;
using Vidsnap.Common.Dto.DataSource;
using Vidsnap.Common.Interfaces.DataSources;
using Vidsnap.Core.Gateways;
using Vidsnap.Core.Interfaces;
using Vidsnap.Core.UseCases;

namespace Vidsnap.Core.Controllers;

public class VideoController(IVideoDataSource videoDataSource) : IVideoController
{
    public async Task<ResultadoOperacao<VideoDto>> CadastrarNovoVideo(VideoSemIdDto videoSemIdDto)
    {
        var gateway = new VideoGateway(videoDataSource);
        var novoVideo = await VideoUseCase.CriarNovoVideo(videoSemIdDto, gateway);

        return novoVideo;
    }
}