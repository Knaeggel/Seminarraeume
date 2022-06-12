using WebApp.Models;
using System.Net.Mail;
using System.Net;
using WebApp.Data;

namespace WebApp.Feature
{
    public class Mail
    {
        public static async Task AutoEmail(Ticket ticket, ApplicationDbContext con)
        {

           
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "raumbuchenhs.offenburg@gmail.com",
                    Password = "iamdupzzvmabhmjl",
                },
            };
            var room = con.Rooms.Find(ticket.room);
            MailAddress FromEmail = new MailAddress("raumbuchenhs.offenburg@gmail.com", "Buchungssystem HS-Offenburg");
            MailAddress ToEmail = new MailAddress(ticket.user, "someone");
            MailMessage messageToSend = new MailMessage()
            {
                From = FromEmail,
                Subject = "Raum ueberbucht",
                Body = "Dein Raum wurde überbucht von einer Person mit höherer Priorität. Raum: " + room.RoomName + " Block: " + ticket.block + " am " + ticket.date.ToString("dd.MM.yyyy")
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
