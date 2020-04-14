using System.ComponentModel.DataAnnotations;


namespace Priyank_P_301112923.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username can't be empty")]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
