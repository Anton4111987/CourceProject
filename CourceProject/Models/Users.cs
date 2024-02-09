using System.ComponentModel.DataAnnotations;

namespace CourceProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Строка имени не может быть пуста")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Строка Фамилии не может быть пуста")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Строка email не может быть пуста")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }




    }
}
