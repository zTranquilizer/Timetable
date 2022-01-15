using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Group
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
