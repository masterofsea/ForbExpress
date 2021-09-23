using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models.Identity
{
    public class UserCreationModel
    {
        [Required] 
        [MaxLength(25)]
        [Display(Name = "User name", Prompt = "User name *")]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Email *")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password *")]
        public string Password { get; set; }
    }
}