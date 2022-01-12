using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;

namespace Timetable.Infrastructure.ServiceModels.Subject
{
    /// <summary>
    ///     Edit subject response model
    /// </summary>
    public class EditSubjectResponseModel
    {
        public SubjectResponseType Type { get; set; }
        public SubjectDto Subject { get; set; }

    }
}
