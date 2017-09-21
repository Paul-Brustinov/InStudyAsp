using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace InStudyAsp.Models.User.Teacher
{
    /*************************************************************************************//**
    * \brief Mail sender
    *****************************************************************************************/
    public class VerificationMailSender
    {
        public MailAddress FromEmail { get; set; }
        public MailAddress ToEmail { get; set; }
        public string FromEmailPassword { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }


        /*************************************************************************************//**
        * \brief Sending mail method
        *****************************************************************************************/
        public void SendVerificationLinkEmail()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromEmail.Address, FromEmailPassword)
            };

            using (var message = new MailMessage(FromEmail, ToEmail)
            {
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true
            }) smtp.Send(message);

        }
    }
}