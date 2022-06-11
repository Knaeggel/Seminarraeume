using WebApp.Models;
using System.Net.Mail;
using System.Net;

namespace WebApp.Feature
{
    public class Mail
    {
        public static async Task AutoEmail(Ticket ticket)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smpt.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "raumbuchenhs.offenburg.com",
                    Password = "9zYS3R5ZVrhxnjk",
                },
            };
            MailAddress FromEmail = new MailAddress("raumbuchenhs.offenburg@gmail.com");
            MailAddress ToEmail = new MailAddress(ticket.user);
            MailMessage messageToSend = new MailMessage()
            {
                From = FromEmail,
                Subject = "Raum ueberbucht",
                Body = "Dein Raum wurde überbucht von einer Person mit höherer Priorität. Raum: " + ticket.room + " Block: " + ticket.block,
            };
            message.To.Add(ToEmail);
            try
            {
                smtp.Send(messageToSend);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
