using System.ComponentModel.DataAnnotations;

namespace TapFinder.Web.Dtos.UserDtos
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