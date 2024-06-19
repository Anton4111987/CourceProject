using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class ChangeUserPassword
    {
        /// <summary>
        /// Текущий пароль
        /// </summary>
        [Required(ErrorMessage = "Строка текущего пароля не может быть пустой")]
        public string? CurrentPassword { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        [Required(ErrorMessage = "Строка нового пароля не может быть пустой")]
        [StringLength(20, MinimumLength = 4)]
        public string? NewPassword { get; set; }

        /// <summary>
        /// Повтор нового пароля
        /// </summary>
        [Required(ErrorMessage = "Строка повтора нового пароля не может быть пустой")]
        public string? NewPasswordRepeat { get; set; }

    }
}
