using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Controllers;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.ServiceModels.Board;
using Timetable.Infrastructure.Services.Interfaces;
using Xunit;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Board controller test
    /// </summary>
    public class BoardControllerTest
    {
        Mock<IBoardService> boardServiceMock;

        public BoardControllerTest()
        {
            boardServiceMock = new Mock<IBoardService>();
        }

        [Fact]
        public async Task GetBoards_ShouldReturn_Boards()
        {
            //arrange
            List<BoardDto> boards = GetTestBoards();

            boardServiceMock.Setup(r => r.GetBoardsAsync()).Returns(Task.FromResult(boards));

            BoardController controller = new BoardController(boardServiceMock.Object);

            //act
            IActionResult? result = await controller.GetBoards();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetBoardById_ShouldReturn_Board()
        {
            //arrange
            var boards = GetTestBoards();

            boardServiceMock.Setup(r => r.GetBoardByIdAsync(boards[0].Id)).Returns(Task.FromResult(boards[0]));

            BoardController controller = new BoardController(boardServiceMock.Object);

            //act
            IActionResult? result = await controller.GetBoard(boards[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddBoard_ShouldReturn_Board()
        {
            //arrange
            BoardDto board = new BoardDto()
            {
                Id = 111,
                GroupId = 11,
                SubjectId = 11,
                TeacherId = 11,
            };

            boardServiceMock.Setup(r => r.CreateBoardAsync(board)).Returns(Task.FromResult(new CreateBoardResponseModel() { Board = board, Type = Infrastructure.Enums.BoardResponseType.Success }));

            BoardController controller = new BoardController(boardServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(board);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<BoardDto> GetTestBoards()
        {
            List<BoardDto> boards = new List<BoardDto>
            {
                new BoardDto
                {
                    Id = 1,
                    GroupId = 1,
                    SubjectId = 1,
                    TeacherId = 1,
                },
                new BoardDto{
                    Id = 2,
                    GroupId = 2,
                    SubjectId = 2,
                    TeacherId = 2,
                }
            };

            return boards;
        }
    }
}
