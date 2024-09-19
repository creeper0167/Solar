using MimeKit.Text;
using MimeKit;
using Solar.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Solar.Application.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("shyann.swift17@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("shyann.swift17@ethereal.email"));
            email.Subject = "Test EMail";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Hello World2</h1>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("shyann.swift17@ethereal.email", "qQtmXTHHsv13AJsMpm");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
