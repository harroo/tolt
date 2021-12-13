
using System;
using System.IO;
using System.Threading;

using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class Program {

            public static void Main (string[] args) {

                Logging.StartNewLog();

                Logging.Log("Starting! ..");

                Logging.Log("OS: " + Environment.OSVersion.ToString().Replace("Unix", "GNU/Linux"));
                Logging.Log("Machine Type: " + (Environment.Is64BitOperatingSystem ? "amd64" : "i386"));
                Logging.Log("Machine Name: " + Environment.MachineName);
                Logging.Log("Running in CLI: " + Environment.CommandLine);
                Logging.Log("Running in C# Build: " + Environment.Version);
                Logging.Log("Working Set: " + Environment.WorkingSet);
                Logging.Log("Working in: " + Environment.CurrentDirectory);

                Logging.Log("Tolt Server. 2021.");

                Logging.Log("Declare Server...");
                Network.Declare();

                Logging.Log("Initialize Components...");

                MessageServer.Init();
                ContentDistribution.Init();

                Logging.Log("Components initialized successfully.");

                Logging.Log("Passing Control to ServerLoop.");

                Loop();
            }

            public static void Loop () {

                while (true) {

                    Network.server.RunCallBacks();

                    Thread.Sleep(4);
                }
            }
        }
    }
}
