using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace SmtpMailingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail();

            Console.ReadLine();
        }

        /// <summary>
        /// Method for sending emails
        /// </summary>
        static void SendEmail()
        {
            string toAddress1 = "rajdeep@promactinfo.com";
            string fromAddress = "rajdeep@promactinfo.com";
            string emailSubject = "Change of Project";
            string emailMessageBody = "Testing";

            var mail = new MailMessage { IsBodyHtml = true };
			
            try
            {
                if (toAddress1 != null)
                {
                    Thread mailSendingThread = new Thread(delegate ()
                    {
                        using (var smtpClient = new SmtpClient())
                        {
                            // SMTP client settings
                            smtpClient.Port = 587;
                            smtpClient.Host = "webmail.promactinfo.com";
                            smtpClient.EnableSsl = false;
                            smtpClient.Credentials = new NetworkCredential("krishna@promactinfo.com", "-lX@d6yA");

                            // Mail settings
                            mail.From = new MailAddress(fromAddress);
                            mail.To.Add(toAddress1);
                            mail.Subject = emailSubject;
                            mail.Body = emailMessageBody;

                            smtpClient.Send(mail);
                        }
                        Console.WriteLine("Sent");
                    });
                    mailSendingThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
