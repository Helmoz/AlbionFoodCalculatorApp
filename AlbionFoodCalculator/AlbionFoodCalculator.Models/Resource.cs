using System.ComponentModel.DataAnnotations;

namespace AlbionFoodCalculator.Models
{
    public class ResourceDto : Resource
    {
        public int Price { get; set; }
    }

    public class Resource
    {
        [Key]
        public string Name { get; set; }
    }
}
