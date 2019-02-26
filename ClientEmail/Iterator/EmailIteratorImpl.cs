using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail.Iterator
{
    public class EmailIteratorImpl : EmailIterator
    {
        private List<Element> list;
        private int index;
        public EmailIteratorImpl(List<Element> list)
        {
            this.list = list;
            this.index = -1;
        }

        public bool hasNext()
        {
            return this.index < this.list.Count() - 1;
        }

        public Element next()
        {
            this.index++;
            return this.list.ElementAt(this.index);
        }

        public Element current()
        {
            return this.list.ElementAt(this.index);
        }

        public void begin()
        {
            this.index = -1;
        }
    }
}
