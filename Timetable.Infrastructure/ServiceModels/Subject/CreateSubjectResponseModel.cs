using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Subject
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
