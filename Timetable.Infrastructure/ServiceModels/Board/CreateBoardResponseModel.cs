using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Board
{
    /// <summary>
    ///     Create board response model
    /// </summary>
    public class CreateBoardResponseModel
    {
        public BoardResponseType Type { get; set; }
        public BoardDto Board { get; set; }
    }
}
