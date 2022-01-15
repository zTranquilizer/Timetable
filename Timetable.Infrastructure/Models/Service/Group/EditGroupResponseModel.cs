using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Group
{
    /// <summary>
    ///     Edit group response model
    /// </summary>
    public class EditGroupResponseModel
    {
        public GroupResponseType Type { get; set; }
        public GroupDto Group { get; set; }

    }
}
