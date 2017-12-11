using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Domain.Entities;
using Service.Patern;
using Data.Infrastructure;

namespace Services
{
    public class ServiceUser : Service<user>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public ServiceUser() : base(utwk)
        {
        }

        public void email(String email,String pass, String subject, String body)
        {
            try { 
             SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(email, pass);
            MailMessage msg = new MailMessage();
            msg.To.Add("wael.benboubaker@esprit.tn");
            msg.From = new MailAddress(email);
            msg.Subject = subject;
            msg.Body = body;
            client.Send(msg);
            } catch(Exception e)
            {
                
            }
        }

        public report getReclamationById()
        {
            return null;
        }
    }
}
