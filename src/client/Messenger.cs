
using System;

using BlitzBit;

namespace Tolt {

    namespace Client {

        public static class Messenger {

            public static void Init () {

                Console.WriteLine("Start Messenger...");

                Network.client.AddPacket(3, OnMessage);

                Console.WriteLine("Done!");
            }

            private static void OnMessage (byte[] data) {

                BlitPacket packet = new BlitPacket(data);

                string sender = packet.GetString();
                string contents = packet.GetString();

                Display.Append(sender, contents);
            }

            public static void SendMessage (string message) {

                BlitPacket packet = new BlitPacket();

                packet.Append(GetUsername());
                packet.Append(message);

                Network.client.Send(3, packet.ToArray());
            }

            private static string GetUsername () {

                return Environment.UserName + "@" + Environment.MachineName;
            }
        }
    }
}
