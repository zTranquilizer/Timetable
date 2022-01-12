using System.ComponentModel.DataAnnotations;

namespace Timetable.Infrastructure.Models
{
    /// <summary>
    ///     Board dto
    /// </summary>
    public class BoardDto
    {
        private DateTime date;

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public DateTime Day
        {
            get
            {
                return date;
            }
            set
            {
                date = value.Date;
            }
        }
        public DateTime Time { get; set; }
    }
}
