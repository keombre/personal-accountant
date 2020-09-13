using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace PersonalAccountant.Entities
{
    public class TypeEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Argb {
            get => Color.ToArgb();
            set => Color = Color.FromArgb(value);
        }

        [NotMapped]
        public Color Color { get; set; }
    }
}
