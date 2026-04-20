using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Range(1, 10)]
        public decimal Rating { get; set; }
        [MaxLength(4096)]
        public string ReviewText { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
