using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Interface
{
    public class ConsoleInterface : IInterface
    {
        public void WriteMessage(string message) => Console.WriteLine(message);
    }
}
