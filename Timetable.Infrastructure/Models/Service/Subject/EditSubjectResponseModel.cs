using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Subject
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
