using System.ComponentModel.DataAnnotations;

namespace CQRSMediator.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
