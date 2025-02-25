using vidsnap.common.Dto.Api;
using vidsnap.common.Dto.DataSource;
using vidsnap.core.Domain.Entities;
using vidsnap.core.Gateways;
using vidsnap.core.Presenters;

namespace vidsnap.core.UseCases;

internal static class VideoUseCase
{
    internal static async Task<ResultadoOperacao<VideoDto>> CriarNovoVideo(VideoSemIdDto videoDto,
        VideoGateway videoGateway)
    {
        try
        {
            //chamar gateway que fala com a fonte de dados para cadastrar video 
            var entidade = new Video(Guid.NewGuid(),
                videoDto.Nome,
                videoDto.Extensao,
                videoDto.Tamanho,
                videoDto.Duracao,
                videoDto.DataCricao,
                videoDto.CaminhoArquivo);

            var novoVideo = await videoGateway.InserirVideoAsync(entidade);
            var retorno = novoVideo
                ? VideoPresenter.ApresentarResultadoVideo(entidade)
                : GeralPresenter.ApresentarResultadoErroLogico<VideoDto>(
                    $"Não foi possível cadastrar video {entidade.Nome}.");

            return retorno;
        }
        catch (Exception ex)
        {
            return GeralPresenter.ApresentarResultadoErroInterno<VideoDto>(ex);
        }
    }
}