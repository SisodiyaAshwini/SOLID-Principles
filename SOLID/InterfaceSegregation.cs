using System;

namespace SOLID
{
//The interface-segregation principle(ISP) states that "no client should be forced to depend on methods it does not use".
//2. Which means, Instead of one fat interface many small interfaces are preferred based on groups of methods with each one serving one submodule.
//3. The ISP was first used and formulated by Robert C.Martin while consulting for Xerox.


//CASE Study

//Problem
//• As we all know Xerox Corporation manufactures printer systems.In their development process of new systems Xerox had created a new
//printer system that could perform a variety of tasks such as stapling and faxing along with the regular printing task.
//• The software for this system was created from the ground up.
//• As the software grew for Xerox, making modifications became more and more difficult so that even the smallest change would take a redeployment cycle of an hour, which made development nearly impossible.
//• The design problem was that a single Job class was used by almost all of the tasks.Whenever a print job or a stapling job needed to be performed, a call was made to the Job class. 
//• This resulted in a 'fat' class with multitudes of methods specific to a variety of different clients.
//Because of this design, a staple job would know about all the methods of the print job, even though there was no use for them.

//Solution
//• To overcome this problem Robert C Martin suggested a solution which is called the Interface Segregation Principle.
//• Which means, Instead of one fat interface many small interfaces are preferred based on groups of methods with each one serving one submodule.

    public interface IPrinterTask
    {
        public bool PrintContent(string Content); //Prints the content
        public bool ScanContent(string content); //Scan the content
        public bool FaxContent(string content); //fax the content
        public bool PhotoCopyContent(string content); //to photo copy the content
    }

    //Now there is one type of printer client, which will use above printer
    public class HPLaserJet : IPrinterTask
    {
        public bool PrintContent(string Content)
        {
            Console.WriteLine("Print Done");
            return true;
        }

        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan Done");
            return true;
        }
        public bool FaxContent(string content)
        {
            Console.WriteLine("Fax Done");
            return true;
        }

        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy Done");
            return true;
        }        
    }

    //Now there is another printer client which came in picture, so now he has to implement the same interface but he doesnt support the fax functionality
    //but still he has to impletemtn the Fax method

    public class CannonMG2470 : IPrinterTask
    {
        public bool PrintContent(string Content)
        {
            Console.WriteLine("Print Done");
            return true;
        }

        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan Done");
            return true;
        }
        
        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy Done");
            return true;
        }

        public bool FaxContent(string content)
        {
            throw new NotImplementedException(); // This is an unnesscary implementation needs to be provided
        }
    }

    //To solve this we should segregate the interface and not force the client to implenet somthing not required
    //Create seperate interface
    public interface IPrinterTask1
    {
        public bool PrintContent(string Content); //Prints the content
        public bool ScanContent(string content); //Scan the content        
        public bool PhotoCopyContent(string content); //to photo copy the content
    }

    interface IFaxContent
    {
        public bool FaxContent(string content); //fax the content
    }

    //This class can implement two interface
    public class HPLaserJet1 : IPrinterTask1, IFaxContent
    {
        public bool FaxContent(string content)
        {
            Console.WriteLine("Fax Done");
            return true;
        }

        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy Done");
            return true;
        }

        public bool PrintContent(string Content)
        {
            Console.WriteLine("Print Done");
            return true;
        }

        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan Done");
            return true;
        }
    }

    // This class can have just basic functionlaity
    public class CannonMG24701 : IPrinterTask1
    {
        public bool PrintContent(string Content)
        {
            Console.WriteLine("Print Done");
            return true;
        }

        public bool ScanContent(string content)
        {
            Console.WriteLine("Scan Done");
            return true;
        }

        public bool PhotoCopyContent(string content)
        {
            Console.WriteLine("PhotoCopy Done");
            return true;
        }
    }

}
