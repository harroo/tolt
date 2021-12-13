
using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class Network {

            public static BlitServer server;

            public static void Declare () {

                server = new BlitServer();
                server.useCallBacks = true;
            }

            public static void Start () {

                server.Start(3737);
            }
        }
    }
}
