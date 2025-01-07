using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDLibraryClasses.Interfaces;

namespace SOLIDLibraryClasses.ClassesForInterfaces
{
    public class ConsoleOutput : IOutput
    {
        public void Print(string message) 
        { 
            Console.WriteLine(message);
        }
    }
}
