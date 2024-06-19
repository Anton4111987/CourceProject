namespace CourceProject.Components.Models
{
    public class SendEmailDataModel
    {
        /// <summary>
        /// Email адресс
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string? Subject { get; set; }
        /// <summary>
        /// Сообщение 
        /// </summary>
        public string? StringMessage { get; set; }


    }
}
