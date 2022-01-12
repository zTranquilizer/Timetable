using Microsoft.EntityFrameworkCore;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;

namespace Timetable.Database.Repositories
{
    /// <summary>
    ///     Board repository
    /// </summary>
    public class BoardRepository : IBoardRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BoardRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get boards async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Board>> GetBoardsAsync()
        {
            return await _databaseContext.Boards.ToListAsync();
        }

        /// <summary>
        ///     Get board by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Board> GetBoardByIdAsync(int id)
        {
            return await _databaseContext.Boards.FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        ///     Get board by teacher id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Board> GetBoardByTeacherIdAsync(int id)
        {
            return await _databaseContext.Boards.FirstOrDefaultAsync(t => t.TeacherId == id);
        }

        /// <summary>
        ///     Get board by group id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Board> GetBoardByGroupIdAsync(int id)
        {
            return await _databaseContext.Boards.FirstOrDefaultAsync(t => t.GroupId == id);
        }

        /// <summary>
        ///     Get board by subject id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Board> GetBoardBySubjectIdAsync(int id)
        {
            return await _databaseContext.Boards.FirstOrDefaultAsync(t => t.SubjectId == id);
        }

        /// <summary>
        ///  Create board async
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public async Task<Board> CreateBoardAsync(Board board)
        {
            _databaseContext.Boards.Add(board);
            await _databaseContext.SaveChangesAsync();

            return board;
        }

        /// <summary>
        ///  Edit board async
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public async Task<Board> EditBoardAsync(Board board)
        {
            _databaseContext.Boards.Update(board);
            await _databaseContext.SaveChangesAsync();

            return board;
        }

        /// <summary>
        ///  Delete board async
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public async Task DeleteBoardAsync(Board board)
        {
            _databaseContext.Boards.Remove(board);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
