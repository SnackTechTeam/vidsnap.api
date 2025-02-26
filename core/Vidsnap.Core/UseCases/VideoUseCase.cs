using Vidsnap.Common.Dto.Api;
using Vidsnap.Common.Dto.DataSource;
using Vidsnap.Core.Domain.Entities;
using Vidsnap.Core.Gateways;
using Vidsnap.Core.Presenters;

namespace Vidsnap.Core.UseCases;

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