
using BlitzBit;

namespace Tolt {

    namespace Client {

        public static class Network {

            public static BlitClient client;

            public static void Declare () {

                client = new BlitClient();
                client.useCallBacks = true;
            }

            public static void Start (string targetAddress) {

                client.Connect(targetAddress, 3737);
            }
        }
    }
}
