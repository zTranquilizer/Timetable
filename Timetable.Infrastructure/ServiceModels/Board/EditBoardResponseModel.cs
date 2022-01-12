using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Board
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
