using S22.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail
{
    public class EmailReceiver
    {

        public List<MailMessage> Messages = new List<MailMessage>();

        public string Username { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public EmailReceiver(string username, string password, string host, int port)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = port;
        }


        public List<MailMessage> DownloadEmails(string mailbox)
        {
            using (ImapClient Client = new ImapClient(Host, Port, Username, Password, AuthMethod.Login, true))
            {
                Console.WriteLine("Descargando Mensajes!...");
                IEnumerable<uint> uids = Client.Search(SearchCondition.All(), mailbox);
                //IEnumerable<MailMessage> messages = Client.GetMessages(uids, true, mailbox);
                Messages = Client.GetMessages(uids, true, mailbox).ToList();
            }

            return Messages;
        }

        public void GetEmails(string mailbox)
        {
            using (ImapClient Client = new ImapClient(Host, Port, Username, Password, AuthMethod.Login, true))
            {
                Console.WriteLine("Descargando Mensajes!...");
                IEnumerable<uint> uids = Client.Search(SearchCondition.All(), mailbox);
                //IEnumerable<MailMessage> messages = Client.GetMessages(uids, true, mailbox);
                Messages = Client.GetMessages(uids, true, mailbox).ToList();
            }
        }

        public MailMessage GetEmail(string mailbox)
        {
            using (ImapClient Client = new ImapClient(Host, Port, Username, Password, AuthMethod.Login, true))
            {
                Console.WriteLine("Descargando Mensajes del folder " + mailbox + "...");
                Console.WriteLine();
                List<uint> uids = Client.Search(SearchCondition.All(), mailbox).ToList();
                Messages = Client.GetMessages(uids, true, mailbox).ToList();
            }

            return Messages.First();
        }
    }
}
