using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        [Required(ErrorMessage = "Строка имени не может быть пуста")]
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Строка Фамилии не может быть пуста")]
        public string? LastName { get; set; }

        /// <summary>
        /// Email адрес
        /// </summary>
        [Required(ErrorMessage = "Строка email не может быть пуста")] 
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [StringLength(20, MinimumLength = 4)]
        public string? Password { get; set; }

        /// <summary>
        /// Дата последнего входа
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

    }
}
