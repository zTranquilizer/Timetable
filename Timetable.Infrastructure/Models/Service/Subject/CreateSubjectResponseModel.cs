using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Subject
{
    /// <summary>
    ///     Create subject response model
    /// </summary>
    public class CreateSubjectResponseModel
    {
        public SubjectResponseType Type { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
