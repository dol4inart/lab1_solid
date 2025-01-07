using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SOLIDLibraryClasses.Interfaces;

namespace SOLIDLibraryClasses.ClassesForInterfaces
{
    public class ConsoleInput : IInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
