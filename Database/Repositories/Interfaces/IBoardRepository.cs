using Timetable.Database.Models;

namespace Timetable.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for board repository
    /// </summary>
    public interface IBoardRepository
    {
        /// <summary>
        ///     Get boards async
        /// </summary>
        /// <returns></returns>
        Task<List<Board>> GetBoardsAsync();

        /// <summary>
        ///     Get board by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Board> GetBoardByIdAsync(int id);

        /// <summary>
        ///     Get board by teacher id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Board> GetBoardByTeacherIdAsync(int id);

        /// <summary>
        ///     Get board by group id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Board> GetBoardByGroupIdAsync(int id);

        /// <summary>
        ///     Get board by subject id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Board> GetBoardBySubjectIdAsync(int id);

        /// <summary>
        ///  Create board async
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        Task<Board> CreateBoardAsync(Board board);

        /// <summary>
        ///  Edit board async
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        Task<Board> EditBoardAsync(Board board);

        /// <summary>
        ///  Delete board async
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        Task DeleteBoardAsync(Board board);
    }
}
