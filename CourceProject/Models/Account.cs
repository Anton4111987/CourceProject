using System.ComponentModel.DataAnnotations;

namespace CourceProject.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Строка ресурса не может быть пуста")]
        public string? Source { get; set; }

        [Required(ErrorMessage = "Строка логина не может быть пуста")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }

        public string? UserId { get; set; }

    }
}
