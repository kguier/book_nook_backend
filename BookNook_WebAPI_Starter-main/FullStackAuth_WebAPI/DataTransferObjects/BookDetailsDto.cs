using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
        [Key]

        public string BookId { get; set; }

        public string Title { get; set; }

        public ICollection<ReviewWithUserDto> Reviews { get; set; }

        public double Ratings { get; set; }

        public Boolean IsFavorite { get; set; }


    }
}
