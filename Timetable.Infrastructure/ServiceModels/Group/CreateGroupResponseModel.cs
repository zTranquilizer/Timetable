using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Group
{
    /// <summary>
    ///     Create group response model
    /// </summary>
    public class CreateGroupResponseModel
    {
        public GroupResponseType Type { get; set; }
        public GroupDto Group { get; set; }
    }
}
