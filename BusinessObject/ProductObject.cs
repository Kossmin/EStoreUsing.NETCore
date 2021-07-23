using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ProductObject
    {
        public ProductObject()
        {
            OrderDetails = new HashSet<OrderDetailObject>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "This is required")]
        [Range(0, 999999)]
        public int ProductId { get; set; }
        [Display(Name = "Category Id")]
        [Required(ErrorMessage = "This is required"), Range(0, 999999, ErrorMessage ="This fill only allow value from 0 to 999999")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This is required"), StringLength(32, MinimumLength = 8, ErrorMessage ="This name is too long or to short")]
        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This is required"), StringLength(32, MinimumLength = 1, ErrorMessage ="This fill is too short or too long")]
        public string Weight { get; set; }
        [Required(ErrorMessage = "This is required"), Range(0, 9999999999999999999, ErrorMessage ="Invalid value")]
        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "This is required"), Range(0, 999999, ErrorMessage ="Invalid value")]
        [Display(Name = "Unit it stock")]
        public int UnitInStock { get; set; }
        public string CoverImgUrl { get; set; }
        public virtual ICollection<OrderDetailObject> OrderDetails { get; set; }
    }
}
