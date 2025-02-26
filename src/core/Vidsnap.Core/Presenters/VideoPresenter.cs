using Vidsnap.Common.Dto.Api;
using Vidsnap.Common.Dto.DataSource;
using Vidsnap.Core.Domain.Entities;

namespace Vidsnap.Core.Presenters;

internal static class VideoPresenter
{
    internal static ResultadoOperacao<VideoDto> ApresentarResultadoVideo(Video video)
    {
        var videoDto = ConverterParaDto(video);
        return new ResultadoOperacao<VideoDto>(videoDto);
    }

    internal static ResultadoOperacao<IEnumerable<VideoDto>> ApresentarResultadoListaVideos(
        IEnumerable<Video> videos)
    {
        var videosDtos = videos.Select(ConverterParaDto);
        return new ResultadoOperacao<IEnumerable<VideoDto>>(videosDtos);
    }

    internal static VideoDto ConverterParaDto(Video video)
    {
        return new VideoDto
        {
            Id = video.Id,
            Nome = video.Nome,
            Extensao = video.Extensao,
            Tamanho = video.Tamanho,
            Duracao = video.Duracao,
            DataCricao = video.DataCricao,
            CaminhoArquivo = video.CaminhoArquivo
        };
    }
}