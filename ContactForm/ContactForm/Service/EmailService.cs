using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using ContactForm.Models;

namespace ContactForm.Service
{
    public class EmailService
    {
        private SmtpClient _smtpClient;
        public EmailService()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials =
                    new NetworkCredential("login", "pass")
            };
        }

        public MailMessage CreateMailMessage(ContactFormModel model)
        {
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("mail"),
                From = new MailAddress("mail"),
                To = { "mail" },
                Subject = model.Subject,
                Body = model.Body,
                IsBodyHtml = true
            };
            return mailMessage;
        }

        public void SendEmail(MailMessage message)
        {
             _smtpClient.Send(message);
        }
      
    }
}