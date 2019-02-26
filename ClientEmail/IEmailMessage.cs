using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail
{
    public interface IEmailMessage 
    {
        string To { get; set; }

        string From { get; set; }

        string Sent { get; set; }

        string CC { get; set; }

        string Subject { get; set; }

        string Body { get; set; }

        void DisplayContent();

        IEmailMessage GetEmailMessage(string mailbox);
    }
}
