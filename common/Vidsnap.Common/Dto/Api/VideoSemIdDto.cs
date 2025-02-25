namespace vidsnap.common.Dto.Api;

public class VideoSemIdDto
{
    public string Nome { get; set; }
    public string Extensao { get; set; }
    public long Tamanho { get; set; }
    public TimeSpan Duracao { get; set; }
    public DateTime DataCricao { get; set; }
    public string CaminhoArquivo { get; set; }
}