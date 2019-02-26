using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientEmail.Iterator;
using ClientEmail.PVisitor;

namespace ClientEmail
{
    public class EmailMessage : Element, IEmailMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Sent { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        private ElementType elementType;

        private List<Element> folderContent = new List<Element>();

        public EmailMessage(string to, string from, string sent, string subject, string body)
        {
            To = to;
            From = from;
            Sent = sent;
            Subject = subject;
            Body = body;
            elementType = ElementType.Message;
        }

        public override void addChildElement(Element element)
        {
            folderContent.Add(element);
        }

        public override void displayContent()
        {
            Console.WriteLine("  To: " + To);
            Console.WriteLine("  From: " + From);
            Console.WriteLine("  Sent: " + Sent);
            Console.WriteLine("  Subject: " + Subject);
            Console.WriteLine("  Body: " + Body);
            Console.WriteLine("  -----------------------------------");
        }

        public override ElementType getType()
        {
            return elementType;
        }

        public bool isValidMessage()
        {
            return !string.IsNullOrEmpty(Subject);
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
            throw new NotImplementedException();
        }

        public override EmailIterator getIterator()
        {
            return null;
        }

        public override Visitor getVisitor(string criteria)
        {
            return null;
        }
    }
}
