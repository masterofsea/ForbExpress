using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models
{
    public class Partner
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(64)]
        [Display(Name = "Партнер")]
        public string Name { get; set; }
        
        
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        
        public string ContactName { get; set; }
        
        //public string AdditionContacts { get; set; }
    }
}