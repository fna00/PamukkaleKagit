using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [Display(Name = "İsim")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Soyisim")]
        public required string Surname { get; set; }

        [Required]
        [Display(Name = "Email Adresi")]
        public required string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Telefon Numarası")]
        public required string PhoneNumber { get; set; }
    }
}