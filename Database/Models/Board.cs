namespace Timetable.Database.Models
{
    /// <summary>
    ///     Board
    /// </summary>
    public class Board
    {
        private DateTime date;

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public DateTime Day {
            get 
            {
                return date;
            }
            set 
            { 
                date = value.Date;
            } 
        }
        public TimeSpan Time { get; set; }

        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}
