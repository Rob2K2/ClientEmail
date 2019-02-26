using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEmail.Iterator
{
    public interface EmailIterator
    {
        bool hasNext();

        Element next();

        Element current();

        void begin();

    }
}
