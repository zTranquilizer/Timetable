using Microsoft.AspNetCore.Mvc;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Board;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("GetBoards")]
        public async Task<IActionResult> GetBoards()
        {
            List<BoardDto> boards = await _boardService.GetBoardsAsync();

            return Ok(boards);
        }

        [HttpGet("GetBoard/{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            BoardDto board = await _boardService.GetBoardByIdAsync(id);

            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BoardDto board)
        {
            CreateBoardResponseModel createBoardResponse = await _boardService.CreateBoardAsync(board);

            if (createBoardResponse.Type == BoardResponseType.Success)
            {
                return Ok(createBoardResponse);
            }

            return BadRequest(createBoardResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BoardDto board)
        {
            EditBoardResponseModel editBoardResponse = await _boardService.EditBoardAsync(id, board);

            if (editBoardResponse.Type == BoardResponseType.Success)
            {
                return Ok(editBoardResponse);
            }

            return BadRequest(editBoardResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            BoardResponseType boardResponse = await _boardService.DeleteBoardAsync(id);

            if (boardResponse == BoardResponseType.Success)
            {
                return Ok(boardResponse);
            }

            return BadRequest(boardResponse);
        }
    }
}
