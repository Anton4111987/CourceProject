using System.ComponentModel.DataAnnotations;

namespace CourceProject.Components.Models
{
    public class SmtpConfig
    {
        /// <summary>
        /// Хост
        /// </summary>
        [Required]
        public string? Host { get; set; }
        /// <summary>
        /// Имя пользователя(email - адрес)
        /// </summary>
        [EmailAddress]
        public string? UserName { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string? Password { get; set; }
        /// <summary>
        /// Порт
        /// </summary>
        [Range(1, ushort.MaxValue)]
        public int Port { get; set; }

        /// <summary>
        /// Метод получения данных с помощью переменных сред
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void GetWithEnvironmentVariable()
        {
            string smtpServer = "smpt-сервер";
            string login = "логинДляОтправкиСообщений";
            string pass = "парольДляОтправкиСообщений";
            string port = "портДляОтправкиСообщений";

            Host = Environment.GetEnvironmentVariable(smtpServer);
            if (Host == null)
            {
                throw new InvalidOperationException($"Переменная среды окружения {smtpServer} не задана ");
            }
            UserName = Environment.GetEnvironmentVariable(login);
            if (UserName == null)
            {
                throw new InvalidOperationException($"Переменная среды окружения {login} не задана ");
            }
            Password = Environment.GetEnvironmentVariable(pass);
            if (Password == null)
            {
                throw new InvalidOperationException($"Переменная среды окружения {pass} не задана ");
            }
            string? portString = Environment.GetEnvironmentVariable(port);
            Port = Convert.ToInt32(portString);
            if (Port == 0)
            {
                throw new InvalidOperationException($"Переменная среды окружения {port} не задана ");
            }
        }
    }
}
