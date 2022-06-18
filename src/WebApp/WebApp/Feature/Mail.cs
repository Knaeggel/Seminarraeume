using WebApp.Models;
using System.Net.Mail;
using System.Net;
using WebApp.Data;

namespace WebApp.Feature
{
    public class Mail
    {
        public static async Task AutoEmail(Ticket ticket, string con)
        {

           
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.ionos.de",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "necip.oezcay@raumbuchenhs-offenburg.de",
                    Password = "Kai123!Nick",
                },
            };

            MailAddress FromEmail = new MailAddress("necip.oezcay@raumbuchenhs-offenburg.de", "Buchungssystem HS-Offenburg");
            MailAddress ToEmail = new MailAddress(ticket.user, "someone");
            MailMessage messageToSend = new MailMessage()
            {
                From = FromEmail,
                Subject = "Raum ueberbucht",
                Body = "Dein Raum wurde überbucht von einer Person mit höherer Priorität. Raum: " + con + " Uhrzeit: " + ticket.getTicketTime().ToString("HH:mm:ss") + " am " + ticket.date.ToString("dd.MM.yyyy")
            };
            messageToSend.To.Add(ToEmail);
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
