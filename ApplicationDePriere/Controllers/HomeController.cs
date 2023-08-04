using ApplicationDePriere.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Org.BouncyCastle.Asn1;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDePriere.Controllers
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
        public IActionResult Form() 
        { 
            return View(); 
        }
        public IActionResult CreerPriere(string unPrenomExpediteur, string unNomExpediteur,string unEmailExpediteur, string unPrenomDestinataire, string unEmailDestinataire, string unSujetPriere, string unePriere)
        {
            string prenom_expe=unPrenomExpediteur;
            string nom_expe = unNomExpediteur;
            string email_expe = unEmailExpediteur; 
            string prenom_dest = unPrenomDestinataire;
            string email_dest = unEmailDestinataire;
            string sPriere= unSujetPriere;
            string priere = unePriere;

            string email = "priereapplication@laposte.net";
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(prenom_expe, email));
            message.To.Add(new MailboxAddress(prenom_dest, email_dest));
            message.Cc.Add(new MailboxAddress(prenom_expe, email_expe));
            message.Subject = sPriere +"De la Part de : " + prenom_dest + " " +nom_expe ;
            message.Body = new TextPart("plain")
            {
                Text = priere
            };

            Smtp(email, message);

            return null; 
            
        }
        public void Smtp(string email, MimeMessage message)
        {
            var smtp = new SmtpClient();

            smtp.Connect("smtp.laposte.net", 587, SecureSocketOptions.Auto);
            smtp.Authenticate(email,"P@ssword12223");
            smtp.Send(message);
            smtp.Disconnect(true);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}