using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail.PVisitor
{
    public interface Visitor
    {
        void visit(Element element);

        List<Element> getVisited();
    }
}
