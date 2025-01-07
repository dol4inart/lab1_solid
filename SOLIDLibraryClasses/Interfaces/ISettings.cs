using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDLibraryClasses.Interfaces
{
    public interface ISettings
    {
        int Min { get; }
        int Max { get; }
        int MaxAttempts { get; }
    }
}
