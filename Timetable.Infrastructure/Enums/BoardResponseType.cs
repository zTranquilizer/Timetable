namespace Timetable.Infrastructure.Enums
{
    /// <summary>
    ///     Board response type
    /// </summary>
    public enum BoardResponseType
    {
        Success,
        BoardUse,
        SubjectUse,
        GroupStudying,
        TeacherWorking,
        TimeOrDayIsBusy,
        BoardNotFound,
        GroupNotFound,
        SubjectNotFound, 
        TeacherNotFound
    }
}
