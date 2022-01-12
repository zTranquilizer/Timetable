using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Teacher
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
