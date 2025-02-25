using vidsnap.common.Dto.Api;
using vidsnap.common.Dto.DataSource;
using vidsnap.common.Interfaces.DataSources;
using vidsnap.core.Gateways;
using vidsnap.core.Interfaces;
using vidsnap.core.UseCases;

namespace vidsnap.core.Controllers;

public class VideoUploaderController(IVideoDataSource videoDataSource) : IVideoUploaderController
{
    public async Task<ResultadoOperacao<VideoDto>> CadastrarNovoVideo(VideoSemIdDto videoSemIdDto)
    {
        var gateway = new VideoGateway(videoDataSource);
        var novoVideo = await VideoUseCase.CriarNovoVideo(videoSemIdDto, gateway);

        return novoVideo;
    }
}