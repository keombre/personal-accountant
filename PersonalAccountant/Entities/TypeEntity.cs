using System.ComponentModel.DataAnnotations;

namespace PersonalAccountant.Entities
{
    public class TypeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Color")]
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string ColorHex { get; set; }
    }
}
