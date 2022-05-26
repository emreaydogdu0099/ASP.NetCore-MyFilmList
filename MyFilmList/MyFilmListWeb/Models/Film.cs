using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFilmListWeb.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Film Name")]
        public string Name { get; set; }

        [DisplayName("IMDb Rating")]
        [Range(1,10,ErrorMessage ="IMDb Rating must be between 1 and 10 only!")]
        public float IMDBRating { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
