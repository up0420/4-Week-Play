using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Api.Dtos;

namespace Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;

    public ChatController(ChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost("with-character")]
    public async Task<IActionResult> ChatWithCharacter([FromBody] ChatWithCharacterRequestDto dto)
    {
        var result = await _chatService.ChatWithCharacterAsync(dto.UserId, dto.CharacterId, dto.Message);
        return Ok(result);
    }
}
