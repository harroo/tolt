
using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class ContentDistribution {

            public static void Init () {

                Logging.Log("Initializing...");

                Network.server.AddPacket(5, OnContentCreate);
                Network.server.AddPacket(6, GetContent);

                Logging.Log("Done!");
            }

            private static void OnContentCreate (int senderId, byte[] data) {

                BlitPacket packet = new BlitPacket(data);

                string sender = packet.GetString();
                string contentId = packet.GetString();
                byte[] buffer = (byte[])packet.GetObject();

                Logging.Log("'" + sender + "' created '" + contentId + "' with a length of: " + buffer.Length);
            }

            private static void GetContent (int senderId, byte[] data) {

                BlitPacket packet = new BlitPacket(data);

                string requester = packet.GetString();
                string contentId = packet.GetString();

                Logging.Log("'" + requester + "' wants '" + contentId + "'.");

                //TODO: send back the content asked for
            }
        }
    }
}
