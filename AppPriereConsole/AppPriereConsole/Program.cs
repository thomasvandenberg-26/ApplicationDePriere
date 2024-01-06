using System;
using MailKit.Net.Smtp;
using MailKit.Security;

using MimeKit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PriereAppConsole
{
  internal class Program
  {
    static void Main(string[] args)
    {

      //Console.WriteLine("TEST");
      //Console.Write("\nEcris ton prénom : ");
      //string prenomExpe = Console.ReadLine();
      //Console.WriteLine("\nEcrire le prénom de ton destinataire : ");
      //string prenomDest = Console.ReadLine();
      Console.WriteLine("\nEcrire son email ");
      string emailDest = Console.ReadLine();
      Console.WriteLine("\nEcrire le sujet de la prière : ");
      string sPriere = Console.ReadLine();
      Console.WriteLine("\n Ecrire la prière pour votre ami : ");
      string pr = Console.ReadLine();

      var message = new MimeMessage();

      string email = "priereapplication@laposte.net";

      Console.ReadLine();

      creerPriere(sPriere, pr, email, emailDest);

    }
    public static void creerPriere(string sPriere, string pr, string email, string emailDest)
    {


      var message = new MimeMessage();
  
      string password = "P@ssword12223";

      string path = "I:/test.m4a"; 

      message.From.Add(new MailboxAddress("Thomas", email));
      message.To.Add(new MailboxAddress("Alice", emailDest));
      message.Cc.Add(new MailboxAddress("Moi", email));
      message.Subject = sPriere;
      var Body = new TextPart("plain")
      {
        Text = pr
      };
      var attachment = new MimePart("audio", "m4a")
      {
        Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        ContentTransferEncoding = ContentEncoding.Base64,
        FileName = Path.GetFileName(path)
      };

   
      var multipart = new Multipart("mixed")
      {
        Body,
        attachment
      };
      message.Body = multipart;
      smtp(message, email, password);
    }
    public static void smtp(MimeMessage message, string email, string password)
    {
      try
      {
        var smtp = new SmtpClient();

        smtp.CheckCertificateRevocation = false;

        smtp.Connect("smtp.laposte.net", 587, SecureSocketOptions.Auto);
        smtp.Authenticate(email, password);
        smtp.Send(message);
        smtp.Disconnect(true);
      }
      catch (Exception error)
      {
        Console.WriteLine(error.ToString());

      }
    }

  }
}

