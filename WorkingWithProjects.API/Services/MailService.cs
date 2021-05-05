using System;
using System.Net;
using System.Net.Mail;

namespace WorkingWithProjects.API.Services
{
    public class MailService : ISentMessageService
    {
        public bool SentMessage(string message, string ownerMessage)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("rasul.ramazanov@nure.ua", "Rasul");
                // кому отправляем
                MailAddress to = new MailAddress($"{ownerMessage}");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Test";
                // текст письма
                m.Body = $"<h2>Test message</h2><br>{message}";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("rasul.ramazanov@nure.ua", "Olya19812203");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
