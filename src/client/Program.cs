
using System;
using System.IO;
using System.Threading;

using BlitzBit;

namespace Tolt {

    namespace Client {

        public static class Program {

            public static void Main (string[] args) {

                Console.WriteLine("Starting! ..");

                Console.WriteLine("OS: " + Environment.OSVersion.ToString().Replace("Unix", "GNU/Linux"));
                Console.WriteLine("Machine Type: " + (Environment.Is64BitOperatingSystem ? "amd64" : "i386"));
                Console.WriteLine("Machine Name: " + Environment.MachineName);
                Console.WriteLine("Running in CLI: " + Environment.CommandLine);
                Console.WriteLine("Running in C# Build: " + Environment.Version);
                Console.WriteLine("Working Set: " + Environment.WorkingSet);
                Console.WriteLine("Working in: " + Environment.CurrentDirectory);

                Console.WriteLine("Tolt Client. 2022.");
                Console.WriteLine();

                if (args.Length != 1) {

                    Console.WriteLine("Invalid Arguments!!");
                    Environment.Exit(-1);
                }

                Console.WriteLine("Starting...");
                Thread.Sleep(1000);

                Network.Declare();

                Messenger.Init();

                Console.WriteLine("Connecting to Server `" + args[0] + "'...");

                if (Network.client.connected != true) {

                    Console.WriteLine("\nFailed to connect to Server!!\nExit...");
                    Environment.Exit(-1);
                }

                Network.Start(args[0]);

                Input.Start();

                Loop();
            }

            public static void Loop () {

                while (true) {

                    Network.client.RunCallBacks();

                    Display.Tick();

                    Thread.Sleep(4);
                }
            }
        }
    }
}
