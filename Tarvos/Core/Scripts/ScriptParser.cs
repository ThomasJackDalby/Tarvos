using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Scripts
{
    public static class ScriptParser
    {
        public static ScriptAction Parse(string input)
        {
            string[] chunks = input.Split(' ').ToArray();
            if (chunks.Length == 0) return null;
            switch (chunks[0])
            {
                default: return null;
            }
        }
    }
}
