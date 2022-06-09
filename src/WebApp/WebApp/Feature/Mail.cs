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
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("raumbuchenhs.offenburg@gmail.com");
            message.To.Add(new MailAddress(ticket.user));
            message.Subject = "Ihr ausgewählter Raum wude überbucht" +" Raum: " + ticket.room + " Block: "+ticket.block.ToString();
            message.IsBodyHtml = true; //to make message body as html  
            smtp.Port = 465;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("raumbuchenhs.offenburg", "9zYS3R5ZVrhxnjk");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
