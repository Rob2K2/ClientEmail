using ClientEmail.Iterator;
using ClientEmail.PVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail
{


    public abstract class Element : Visitable
    {
        public static string FOLDER_INBOX_NAME = "Inbox";

        public static string FOLDER_SENT_NAME = "Send";

        public static string FOLDER_TRASH_NAME = "Trash";

        public abstract void addChildElement(Element element);

        public abstract void displayContent();

        public abstract ElementType getType();

        public abstract EmailIterator getIterator();

        public abstract Visitor getVisitor(String criteria);

        public void accept(Visitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
