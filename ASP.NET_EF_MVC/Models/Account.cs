using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Account
    {
        [Key]
        [Required]
        public string Email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}