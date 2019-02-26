using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail.Adapter
{
    public class EmailReceiverAdapter : IEmailMessage
    {
        private EmailReceiver _emailReceiver;

        public string To { get; set; }
        public string From { get; set; }
        public string Sent { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public EmailReceiverAdapter(string username, string password, string host, int port)
        {
            _emailReceiver = new EmailReceiver(username, password, host, port);
        }

        public void DisplayContent()
        {
            Console.WriteLine("  To: " + To);
            Console.WriteLine("  From: " + From);
            Console.WriteLine("  Sent: " + Sent);
            Console.WriteLine("  Subject: " + Subject);
            Console.WriteLine("  Body: " + Body);
            Console.WriteLine("  -----------------------------------");
        }

        public IEmailMessage GetEmailMessage(string mailbox)
        {
            _emailReceiver.GetEmail(mailbox);

            string to = _emailReceiver.Messages[0].To[0].Address;
            string from = _emailReceiver.Messages[0].From.Address;
            string sent = "01/02/2019";
            string subject = _emailReceiver.Messages[0].Subject;
            string body = _emailReceiver.Messages[0].Body;

            var emailMessage = new EmailMessage(to,from,sent,subject,body);

            return emailMessage;
        }
    }
}
