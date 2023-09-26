using MailKit.Net.Smtp;
using MailSenderDemo.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MailSenderDemo.Controllers
{
    public class MailController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("User","example@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("example@gmail.com", "Password--"); //ryyf fikf xbvm nllr
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }

    }
}
