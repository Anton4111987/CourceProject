using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class ChangeUserPassword
    {
        [Required(ErrorMessage = "Строка текущего пароля не может быть пустой")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "Строка нового пароля не может быть пустой")]
        [StringLength(20, MinimumLength = 4)]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Строка повтора нового пароля не может быть пустой")]
        public string? NewPasswordRepeat { get; set; }

    }
}
