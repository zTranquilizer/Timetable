using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Teacher
{
    /// <summary>
    ///     Edit teacher response model
    /// </summary>
    public class EditTeacherResponseModel
    {
        public TeacherResponseType Type { get; set; }
        public TeacherDto Teacher { get; set; }

    }
}
