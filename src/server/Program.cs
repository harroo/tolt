
using System;
using System.IO;

using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class Program {

            public static void Main (string[] args) {

                Logging.StartNewLog();

                Logging.Log("Starting! ..");

                Logging.Log("OS: " + Environment.OSVersion);
                Logging.Log("Machine Type: " + (Environment.Is64BitOperatingSystem ? "amd64" : "i386"));
                Logging.Log("Machine Name: " + Environment.MachineName);
                Logging.Log("Running in CLI: " + Environment.CommandLine);
                Logging.Log("Running in C# Build: " + Environment.Version);
                Logging.Log("Working Set: " + Environment.WorkingSet);
                Logging.Log("Working in: " + Environment.CurrentDirectory);

                Logging.Log("Tolt Server. 2021.");

                Logging.Log("Declare Server...");

                

                Logging.Log("Initialize Components...");


            }
        }
    }
}
