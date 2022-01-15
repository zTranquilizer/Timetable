using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Board
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
