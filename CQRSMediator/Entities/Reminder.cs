using System.ComponentModel.DataAnnotations;

namespace CQRSMediator.Entities
{
    public class Reminder
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? DateToRemind { get; set; }
    }
}
