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
        public void SendEmail(string destination,string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("shyann.swift17@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(destination));
            email.Subject = "Test EMail";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>" + body + "</h1>" };

            using var smtp = new SmtpClient();
            smtp.Connect("23.88.115.132", 587, MailKit.Security.SecureSocketOptions.None);
            smtp.Authenticate("bahman@wvpp.com.au", "123456");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
