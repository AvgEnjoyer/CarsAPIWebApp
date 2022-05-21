using System.ComponentModel.DataAnnotations;

namespace CarsAPIWebApp.Models
{
    public class Brand
    {

        public Brand()
        {
            Cars = new HashSet<Car>();  
        }
        
        [Key]
        public int BrandId { get; set; }
        [Display(Name="Марка авто")]
        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        public string BrandName { get; set; } 

        public virtual ICollection<Car> Cars { get; set; }
    }
}
