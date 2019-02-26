using ClientEmail.Adapter;
using ClientEmail.PVisitor;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese cadena a buscar en todos los mensajes de perico0001@gmx.com eg: Perico");

            string searchCriteria = Console.ReadLine();

            Console.WriteLine("Buscando mensajes que contengan la cadena: " + searchCriteria + "");

            List<Element> emailList = createFakeEmails();

            List<Element> emailsFound = new List<Element>();

            foreach (Element email in emailList)
            {
                Visitor visitor = email.getVisitor(searchCriteria);
                visitor.visit(email);
                List<Element> visited = visitor.getVisited();
                emailsFound.AddRange(visited);
            }

            Console.WriteLine("Resultado de la búsqueda: " + searchCriteria + "");
            foreach (var item in emailsFound)
            {
                item.displayContent();
            }

            Console.WriteLine("Fin de la búsqueda:");

            Console.ReadLine();
        }

        private static List<Element> createFakeEmails()
        {
            string host = "imap.gmx.com";
            int port = 993;
            string username = "perico0001@gmx.com";
            string password = "0001Perico";
            EmailReceiverAdapter era = new EmailReceiverAdapter(username, password, host, port);

            List<Element> list = new List<Element>();

            EmailFolder folderInbox = new EmailFolder("Inbox");
            folderInbox.addChildElement((Element)era.GetEmailMessage("INBOX"));
            //folderInbox.addChildElement(getFakeEmail02());

            EmailFolder folderSent = new EmailFolder("Sent");
            folderSent.addChildElement((Element)era.GetEmailMessage("Sent"));

            EmailFolder folderTrash = new EmailFolder("Trash");
            folderTrash.addChildElement((Element)era.GetEmailMessage("Trash"));

            EmailFolder folderImportant = new EmailFolder("Important");

            list.Add(folderInbox);
            list.Add(folderSent);
            list.Add(folderTrash);
            list.Add(folderImportant);

            return list;
        }

       
    }
}
