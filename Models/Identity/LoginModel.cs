using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models.Identity
{
    public class LoginModel
    {
        // ReSharper disable once Mvc.TemplateNotResolved
        [Required]
        public string Name { get; set; }

        [Required]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        public string Password { get; set; }

        public bool KeepLoggedIn { get; set; }
    }
}