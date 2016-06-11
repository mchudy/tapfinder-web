using System.ComponentModel.DataAnnotations;

namespace PubApp.Web.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        [Compare(nameof(OldPasswordConfirm))]
        public string OldPassword { get; set; }

        [Required]
        public string OldPasswordConfirm { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}