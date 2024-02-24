using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class UserAthirization
    {
        [Required(ErrorMessage = "Строка имени не может быть пуста")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }
    }
}
