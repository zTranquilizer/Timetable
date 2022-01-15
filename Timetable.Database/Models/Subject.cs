namespace Timetable.Database.Models
{
    /// <summary>
    ///     Subject
    /// </summary>
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public List<Board> Boards { get; set; }
        public List<Group> Groups { get; set; }
        public List<Teacher> Teachers { get; set; }


    }
}
