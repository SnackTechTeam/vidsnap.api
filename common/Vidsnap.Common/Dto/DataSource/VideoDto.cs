namespace Vidsnap.Common.Dto.DataSource;

public class VideoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Extensao { get; set; } = string.Empty;
    public long Tamanho { get; set; } = 0;
    public TimeSpan Duracao { get; set; } = TimeSpan.Zero;
    public DateTime DataCricao { get; set; }
    public string CaminhoArquivo { get; set; } = string.Empty;
}