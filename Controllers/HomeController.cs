using business_card.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace business_card.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult ContactMe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactMe(string name, string email, string message)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("quram21@gmail.com");
            mail.To.Add("quram21@gmail.com");
            mail.ReplyToList.Add(new MailAddress(email));
            mail.Subject = "New message from contact form";
            mail.Body = $"Name: {name}\nEmail: {email}\nMessage:\n{message}";

            using (var smtp = new SmtpClient("smtp.gmail.com", 587)) {
                smtp.Credentials = new NetworkCredential("quram21@gmail.com", "rjxh tipr tqkj gysf");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }

            ViewBag.Success = true;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
