﻿using Microsoft.AspNetCore.Mvc;
using vidsnap.api.CustomResponses;
using vidsnap.common.Dto.Api;

namespace vidsnap.api.Controllers;

public abstract class CustomBaseController(ILogger logger) : ControllerBase
{
    private readonly ILogger logger = logger;

    internal async Task<IActionResult> ExecucaoPadrao<T>(string nomeMetodo, Task<ResultadoOperacao<T>> processo)
    {
        try
        {
            var resultado = await processo;

            if (resultado.TeveSucesso())
                return Ok(resultado.Dados);

            if (resultado.TeveExcecao())
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse(resultado.Mensagem, new ExceptionResponse(resultado.Excecao)));

            var errorResponse = new ErrorResponse(resultado.Mensagem, null);
            return BadRequest(errorResponse);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Metodo} - Exception - {Message}", nomeMetodo, ex.Message);
            var retorno = new ErrorResponse(ex.Message, new ExceptionResponse(ex));
            return StatusCode(StatusCodes.Status500InternalServerError, retorno);
        }
    }

    internal async Task<IActionResult> ExecucaoPadrao(string nomeMetodo, Task<ResultadoOperacao> processo)
    {
        try
        {
            var resultado = await processo;

            if (resultado.TeveSucesso())
                return Ok();

            if (resultado.TeveExcecao())
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse(resultado.Mensagem, new ExceptionResponse(resultado.Excecao)));

            var errorResponse = new ErrorResponse(resultado.Mensagem, null);
            return BadRequest(errorResponse);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Metodo} - Exception - {Message}", nomeMetodo, ex.Message);
            var retorno = new ErrorResponse(ex.Message, new ExceptionResponse(ex));
            return StatusCode(StatusCodes.Status500InternalServerError, retorno);
        }
    }
}