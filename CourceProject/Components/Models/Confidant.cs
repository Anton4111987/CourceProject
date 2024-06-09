using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    /// <summary>
    /// Класс доверенное лицо
    /// </summary>
    public class Confidant
    {
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Строка Фамилии не может быть пуста")]
        public string? LastName { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        [Required(ErrorMessage = "Строка имени не может быть пуста")]
        public string? Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required(ErrorMessage = "Строка Отчества не может быть пуста")]
        public string? SurName { get; set; }

        /// <summary>
        /// email адрес
        /// </summary>
        [Required(ErrorMessage = "Строка email не может быть пуста")]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// номер сотового телефона
        /// </summary>
        [Required(ErrorMessage = "Номер не может быть пустым")]
        [Phone(ErrorMessage = "Некорректный номер телефона")] 
        [StringLength(12, MinimumLength = 6)]
        public long? Number { get; set; }

        public int? UserId { get; set; }


    }
}
