using Vidsnap.Common.Dto.DataSource;
using Vidsnap.Common.Interfaces.DataSources;
using Vidsnap.Core.Domain.Entities;

namespace Vidsnap.Core.Gateways;

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