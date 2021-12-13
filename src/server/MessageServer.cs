
using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class MessageServer {

            public static void Init () {

                Logging.Log("Initializing...");

                Network.server.AddPacket(3, OnMessage);
                Network.server.AddPacket(4, GetMessages);

                Logging.Log("Done!");
            }

            private static void OnMessage (int senderId, byte[] data) {

                BlitPacket packet = new BlitPacket(data);

                string sender = packet.GetString();
                string contents = packet.GetString();

                Logging.Log("<" + sender + "> " + contents);
            }

            private static void GetMessages (int senderId, byte[] data) {

                BlitPacket packet = new BlitPacket(data);

                string requester = packet.GetString();
                string channelId = packet.GetString();
                int messageCount = packet.GetInt32();

                Logging.Log("'" + requester + "' asked for " + messageCount + " message(s) from '" + channelId + "'.");

                //TODO: send back the messages asked for
            }
        }
    }
}
