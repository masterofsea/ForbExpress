using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models
{
    //TODO уточнить какие из полей необходимо заполнять
    public class Lessee
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(64)]
        [Display(Name = "Полное название")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(32)]
        [Display(Name = "Короткое название")]
        public string ShortName { get; set; }
        
        
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        
        [Display(Name = "Дополнительные контакты")]
        public string AdditionalContacts { get; set; }
        
        [Display(Name = "Контактное лицо")]
        public string ContactName { get; set; }
        
        [Display(Name = "Должность контактного лица")]
        public string ContactNamePosition { get; set; }
        
        //TODO навесить ограничения на реквизиты
        [Required]
        [Display(Name = "ИНН")]
        public string Inn { get; set; }
        
        [Display(Name = "Банк")]
        public string Bank { get; set; }
        
        [Display(Name = "БИК")]
        public string Bic { get; set; }
        
        [Display(Name = "ОГРН")]
        public string Ogrn { get; set; }
        
        [Display(Name = "КПП")]
        public string Kpp { get; set; }
        
        [Display(Name = "Расчетный счет")]
        public string CheckingAccount { get; set; }
    }
}