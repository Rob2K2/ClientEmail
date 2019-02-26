using ClientEmail.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail.PVisitor
{
    public class FindEmail : Visitor
    {
        private List<Element> emailsFound;

        private string criteria;

        public FindEmail(String criteria)
        {
            this.criteria = criteria;
            this.emailsFound = new List<Element>();
        }

        
    public void visit(Element element)
        {
            EmailIterator it = element.getIterator();
            while (it.hasNext())
            {
                if (it.next().getType() == ElementType.Message)
                {
                    IEmailMessage item = (IEmailMessage)it.current();
                    if (item.From.Contains(this.criteria) ||
                        item.Subject.Contains(this.criteria) ||
                        item.Body.Contains(this.criteria))
                    {
                        this.emailsFound.Add(it.current());
                    }
                }

            }
        }
                
    public List<Element> getVisited()
        {
            return this.emailsFound;
        }
    }
}
