using System.ComponentModel.DataAnnotations;

namespace TabloidMVC.Models
{
    public class Credentials
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
