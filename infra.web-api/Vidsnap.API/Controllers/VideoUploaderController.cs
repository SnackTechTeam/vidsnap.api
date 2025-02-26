using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vidsnap.Common.Dto.Api;
using Vidsnap.Core.Interfaces;

namespace Vidsnap.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoUploaderController(
    ILogger<VideoUploaderController> logger,
    IVideoUploaderController videoUploaderController) : CustomBaseController(logger)
{
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Cadastra um novo vídeo no sistema")]
    public async Task<IActionResult> Post([FromBody] VideoSemIdDto novoVideo)
    {
        return await ExecucaoPadrao("Video.Post", videoUploaderController.UploadVideo(novoVideo));
    }
}