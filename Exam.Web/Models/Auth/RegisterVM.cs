using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exam.Web.Models.Auth
{
    public class RegisterVM
    {
        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        [PasswordPropertyText]
        [Compare(nameof(Password),ErrorMessage ="Passwords should match!")]
        public string RePassword { get; set; }
    }
}
