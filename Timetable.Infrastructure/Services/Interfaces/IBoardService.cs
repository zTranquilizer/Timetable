using Timetable.Database.Models;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Board;

namespace Timetable.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for board service
    /// </summary>
    public interface IBoardService
    {
        /// <summary>
        ///     Get boards async
        /// </summary>
        /// <returns></returns>
        Task<List<BoardDto>> GetBoardsAsync();

        /// <summary>
        ///     Get board by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BoardDto> GetBoardByIdAsync(int id);

        /// <summary>
        ///  Create board async
        /// </summary>
        /// <param name="boardDto"></param>
        /// <returns></returns>
        Task<CreateBoardResponseModel> CreateBoardAsync(BoardDto boardDto);

        /// <summary>
        ///  Edit board async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="boardDto"></param>
        /// <returns></returns>
        Task<EditBoardResponseModel> EditBoardAsync(int id, BoardDto boardDto);

        /// <summary>
        ///  Delete board async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BoardResponseType> DeleteBoardAsync(int id);
    }
}
