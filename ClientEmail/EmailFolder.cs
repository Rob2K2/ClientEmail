using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientEmail.Iterator;
using ClientEmail.PVisitor;

namespace ClientEmail
{
    public class EmailFolder : Element
    {
        public string FolderName { get; set; }

        public ElementType ElementType { get; set; }
        
        public List<Element> FolderContent = new List<Element>();

        public EmailFolder(string folderName)
        {
            FolderName = folderName;
            ElementType = ElementType.Folder;
        }

        public override void addChildElement(Element element)
        {
            FolderContent.Add(element);
        }

        public override void displayContent()
        {
            Console.WriteLine(">>" + FolderName);
            
            foreach (var element in FolderContent)
            {
                element.displayContent();
            }
        }

        public override ElementType getType()
        {
            return ElementType;
        }

        public override EmailIterator getIterator()
        {
            return new EmailIteratorImpl(this.FolderContent);
        }

        public override Visitor getVisitor(string criteria)
        {
            return new FindEmail(criteria);
        }
    }
}
