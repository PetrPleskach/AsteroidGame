using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Logging
{
    internal abstract class Logger
    {
        public bool Enabled { get; set; }
        public abstract void Log(string message);

        public void LogInfo(string message) => Log($"{DateTime.Now:G} [info]: {message}");

        public void LogError(string message) => Log($"{DateTime.Now:G} [error]: {message}");

    }
}
