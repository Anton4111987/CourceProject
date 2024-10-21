using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class Account
    {
        /// <summary>
        /// Идентификатор аккаунта 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ресурс, аккаунт
        /// </summary>
        [Required(ErrorMessage = "Строка ресурса не может быть пуста")]
        public string? Source { get; set; }

        /// <summary>
        /// Логин 
        /// </summary>
        [Required(ErrorMessage = "Строка логина не может быть пуста")]
        public string? Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }

        /// <summary>
        /// Идентификатор пользователя (внешний ключ)
        /// </summary>
        public int? UserId { get; set; }

    }
}
