namespace Timetable.Database.Models
{
    /// <summary>
    ///     Group
    /// </summary>
    public class Group
    {
        public int Id { get; set; }
        public int GroupNumber { get; set; }

        public List<Board> Boards { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
