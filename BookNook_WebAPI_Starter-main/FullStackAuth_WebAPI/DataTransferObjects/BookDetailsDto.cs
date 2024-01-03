using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
        [Key]

        public string BookId { get; set; }

        public List<ReviewWithUserDto> Reviews { get; set; }

        public double AverageRating { get; set; }

        public bool IsFavorite { get; set; }

    }
}
