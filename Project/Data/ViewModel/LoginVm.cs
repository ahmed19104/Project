using System.ComponentModel.DataAnnotations;

namespace Project.Data.ViewModel
{
    public class LoginVm
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
