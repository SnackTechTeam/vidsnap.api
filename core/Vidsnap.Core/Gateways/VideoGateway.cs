using vidsnap.common.Dto.DataSource;
using vidsnap.common.Interfaces.DataSources;
using vidsnap.core.Domain.Entities;

namespace vidsnap.core.Gateways;

internal class VideoGateway(IVideoDataSource dataSource)
{
    internal async Task<Video?> InserirVideoAsync(Video videoNovo)
    {
        var dto = ConverterParaDto(videoNovo);
        return await dataSource.InserirVideoAsync(dto);
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