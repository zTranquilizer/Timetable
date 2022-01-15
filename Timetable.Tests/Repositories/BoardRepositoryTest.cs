using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Timetable.Database;
using Timetable.Database.Models;
using Timetable.Database.Repositories;
using Xunit;

namespace Timetable.Tests.Repositories
{
    /// <summary>
    ///     Board repository test
    /// </summary>
    public class BoardRepositoryTest
    {

        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public BoardRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetBoards_ShouldReturn_Boards()
        {
            //arange
            ClearDatabase(context);

            var boardsNew = AddDb(context);

            var boardRepository = new BoardRepository(context);

            //act
            var result = await boardRepository.GetBoardsAsync();

            //assert
            boardsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetBoardById_ShouldReturn_Board()
        {
            //arrange
            ClearDatabase(context);

            var boardsNew = AddDb(context);

            var boardRepository = new BoardRepository(context);

            //act
            var result = await boardRepository.GetBoardByIdAsync(boardsNew[0].Id);

            //assert
            boardsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddBoard_ShouldReturn_Board()
        {
            //arrange
            var board = new Board
            {
                Id = 11,
                GroupId = 1,
                TeacherId = 1,
                SubjectId = 1,
                Day = DateTime.Now,
                Time = DateTime.Now
            };

            var boardRepository = new BoardRepository(context);

            //act
            var result = await boardRepository.CreateBoardAsync(board);

            //assert
            board.Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task EditBoard_ShouldReturn_Board()
        {
            //arrange
            ClearDatabase(context);

            var boardsNew = AddDb(context);
            var boardRepository = new BoardRepository(context);

            //act
            var result = await boardRepository.EditBoardAsync(boardsNew[0]);

            //assert
            boardsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteBoard_ShouldReturn_Board()
        {
            //arrange
            ClearDatabase(context);

            var boardsNew = AddDb(context);
            var boardRepository = new BoardRepository(context);

            //act
            await boardRepository.DeleteBoardAsync(boardsNew[1]);

            //assert
            Assert.True(context.Boards.FirstOrDefault(t => t.Id == boardsNew[1].Id) == null);
        }

        private Board[] AddDb(DatabaseContext database)
        {
            var boardsNew = new[] {

                new Board
               {
                Id = 1,
                GroupId = 1,
                TeacherId = 1,
                SubjectId = 1,
                Day = DateTime.Now,
                Time = DateTime.Now
            },

            new Board
                {
                Id = 2,
                GroupId = 1,
                TeacherId = 1,
                SubjectId = 1,
                Day = DateTime.Now,
                Time = DateTime.Now
            }
        };

            database.Boards.AddRange(boardsNew);
            database.SaveChanges();

            return boardsNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Boards)
                context.Boards.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
