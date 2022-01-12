using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Group
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
