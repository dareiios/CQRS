using System.ComponentModel.DataAnnotations;

namespace CQRSMediator.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
