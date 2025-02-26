namespace Vidsnap.Core.Domain.Entities;

//TODO: Implementar os types
internal class Video(
    Guid id,
    string nome,
    string extensao,
    long tamanho,
    TimeSpan duracao,
    DateTime dataCriacao,
    string caminhoArquivo)
{
    internal Guid Id { get; private set; }
    internal string Nome { get; private set; } = string.Empty;
    internal string Extensao { get; private set; } = string.Empty;
    internal long Tamanho { get; private set; } = 0;
    internal TimeSpan Duracao { get; private set; } = TimeSpan.Zero;
    internal DateTime DataCricao { get; private set; }
    internal string CaminhoArquivo { get; private set; } = string.Empty;
}