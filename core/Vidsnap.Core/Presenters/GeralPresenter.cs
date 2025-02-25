using vidsnap.common.Dto.Api;

namespace vidsnap.core.Presenters;

internal static class GeralPresenter
{
    internal static ResultadoOperacao<T> ApresentarResultadoErroLogico<T>(string mensagem)
    {
        return new ResultadoOperacao<T>(mensagem, true);
    }

    internal static ResultadoOperacao ApresentarResultadoErroLogico(string mensagem)
    {
        return new ResultadoOperacao(mensagem);
    }

    internal static ResultadoOperacao<T> ApresentarResultadoErroInterno<T>(Exception excecao)
    {
        return new ResultadoOperacao<T>(excecao);
    }

    internal static ResultadoOperacao ApresentarResultadoErroInterno(Exception excecao)
    {
        return new ResultadoOperacao(excecao);
    }

    internal static ResultadoOperacao ApresentarResultadoPadraoSucesso()
    {
        return new ResultadoOperacao();
    }
}