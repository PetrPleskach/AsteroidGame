using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AsteroidGame.Logging
{
    class TextFileLogger : Logger
    {
        private readonly TextWriter writer;
        public TextFileLogger(string fileName, bool enabled)
        {
            Enabled = enabled;
            if(enabled)
                writer = File.CreateText(fileName);            
        }

        public override void Log(string message)
        {
            if (Enabled)
            {
                writer.WriteLine(message);
                writer.Flush();
            }          
        }
    }
}
