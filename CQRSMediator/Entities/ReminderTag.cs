using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediator.Entities
{
    public class ReminderTag
    {
        public int ReminderId { get; set; }

        [ForeignKey("ReminderId")]
        public Reminder Reminder { get; set; }

        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }


    }
}
