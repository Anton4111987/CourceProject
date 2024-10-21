using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class UserAuthorization
    {
        /// <summary>
        /// Имя пользователя 
        /// </summary>
        [Required(ErrorMessage = "Строка имени не может быть пуста")]
        public string? Name { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }
    }
}
