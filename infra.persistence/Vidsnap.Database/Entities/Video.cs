namespace Vidsnap.Database.Entities;

public class Video
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Extensao { get; set; }
    public long Tamanho { get; set; }
    public TimeSpan Duracao { get; set; }
    public DateTime DataCricao { get; set; }
    public string CaminhoArquivo { get; set; }
}