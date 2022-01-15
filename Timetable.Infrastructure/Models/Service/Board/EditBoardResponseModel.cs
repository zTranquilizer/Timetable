using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Board
{
    /// <summary>
    ///     Edit board response model
    /// </summary>
    public class EditBoardResponseModel
    {
        public BoardResponseType Type { get; set; }
        public BoardDto Board { get; set; }

    }
}
