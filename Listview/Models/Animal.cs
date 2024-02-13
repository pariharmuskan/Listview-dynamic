using System.ComponentModel.DataAnnotations;

namespace Listview.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] AniImage { get; set; }
    }
}
