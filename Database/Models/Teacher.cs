namespace Timetable.Database.Models
{
    /// <summary>
    ///     Teacher
    /// </summary>
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Board> Boards { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
