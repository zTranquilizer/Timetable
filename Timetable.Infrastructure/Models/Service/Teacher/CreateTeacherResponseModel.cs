using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Teacher
{
    /// <summary>
    ///     Create teacher response model
    /// </summary>
    public class CreateTeacherResponseModel
    {
        public TeacherResponseType Type { get; set; }
        public TeacherDto Teacher { get; set; }
    }
}
