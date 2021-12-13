
using System;
using System.IO;
using System.Threading;

namespace Tolt {

    namespace Server {

        public static class Logging {

            private static string logFilePath;

            public static void StartNewLog () {

                DateTime dateTime = DateTime.Now;

                string dateString = (dateTime.Month + "-" + dateTime.Day + "-" + dateTime.Year);

                if (!Directory.Exists("logs"))
                    Directory.CreateDirectory("logs");

                logFilePath = "logs/" + ("log_" + dateString + "_0.txt");
                int logFileCount = 0;

                while (File.Exists(logFilePath)) {

                    logFileCount++;

                    logFilePath = "logs/" + ("log_" + dateString + "_" + logFileCount.ToString() + ".txt");
                }
            }

            private static Mutex mutex = new Mutex();

            public static void Log (string message) {

                string callingMethod =
                    (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().DeclaringType.FullName + "." +
                    (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;

                Log(callingMethod, message);
            }

            public static void Log (string sender, string message) {

                mutex.WaitOne();

                string logMessage = "[" + DateTime.Now + "] [" + sender + "]: " + message;

                Console.WriteLine(logMessage);

                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);

                mutex.ReleaseMutex();
            }
        }
    }
}
