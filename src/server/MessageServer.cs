
using System.IO;
using System.Collections.Generic;

using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class MessageServer {

            public static void Init () {

                Logging.Log("Initializing...");

                Network.server.AddPacket(PacketId.SubscribeToChannel, OnSubscribe);
                Network.server.AddPacket(PacketId.UnsubscribeToChannel, OnUnsubscribe);

		Network.server.AddPacket(PacketId.GetFromChannel, GetFromChannel);
		Network.server.AddPacket(PacketId.SendToChannel, SendToChannel);

                Logging.Log("Done!");
            }

	    private static void Dictionary<string, List<int>> channelSubscriptions
		    = new Dictionary<string, List<int>>();

	    private static void OnSubscribe (int senderId, byte[] data) {

		    BlitPacket recvPacket = new BlitPacket(data);

		    string userAgent = recvPacket.GetString();
		    string sender = recvPacket.GetString();

		    string channelId = recvPacket.GetString();

		    if (!channelSubscriptions.ContainsKey(channelId))
			    channelSubscriptions.Add(channelId, new List<int>());

		    //if channel subscriptions for the channel id dont contain this sender id add it
	    }

	    //continue on with that
        }
    }
}
