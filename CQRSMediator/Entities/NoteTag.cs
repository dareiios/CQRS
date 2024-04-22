using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediator.Entities
{
    public class NoteTag
    {
        public int NoteId { get; set; }

        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
