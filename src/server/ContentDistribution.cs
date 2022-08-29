
using System.IO;
using System.Collections.Generic;

using BlitzBit;

namespace Tolt {

    namespace Server {

        public static class ContentDistribution {

            public static void Init () {

                Logging.Log("Initializing...");

                Network.server.AddPacket(PacketId.SubscribeContentSubmissions, OnSubscribe);
                Network.server.AddPacket(PacketId.UnsubscribeContentSubmissions, OnUnsubscribe);

		Network.server.AddPacket(PacketId.SubmitContent, OnSubmission);
		Network.server.AddPacket(PacketId.GetContent, OnGet);

		if (!Directory.Exists("cdn")) Directory.CreateDirectory("cdn");

                Logging.Log("Done!");
            }

	    private static List<int> subscriptionList = new List<int>(); 

	    private static void OnSubscribe (int senderId, byte[] data) {

		    BlitPacket recvPacket = new BlitPacket(data);

		    string userAgent = recvPacket.GetString();
		    string sender = recvPacket.GetString();

		    if (!subscriptionList.Contains(senderId))
			    subscriptionList.Add(senderId);

		    Logging.Log(userAgent + "::" + sender + "; Subscribed to content submissions.");
	    }
            private static void OnUnsubscribe (int senderId, byte[] data) {

		    BlitPacket recvPacket = new BlitPacket(data);

		    string userAgent = recvPacket.GetString();
		    string sender = recvPacket.GetString();

		    if (subscriptionList.Contains(senderId))
			    subscriptionList.Remove(senderId);

		    Logging.Log(userAgent + "::" + sender + "; Unsubscribed from content submissions.");
	    }

	    private static void OnSubmission (int senderId, byte[] data) {

		    BlitPacket recvPacket = new BlitPacket(data);

		    string userAgent = recvPacket.GetString();
		    string sender = recvPacket.GetString();

		    string contentId = recvPacket.GetString();
		    byte[] contentData = recvPacket.GetByteArray();

		    SaveContent(contentId, contentData);

		    BlitPacket contentPacket = new BlitPacket();
		    contentPacket.Append(contentId);
		    contentPacket.Append(contentData);
		    foreach (int subscriber in subscriptionList)
			    Network.server.RelayTo(PacketId.SubmitContent, subscriber, contentPacket.ToArray());

		    Logging.Log(userAgent + "::" + sender + "; Submitted content: " + contentId + ", length of: " + contentData.Length.ToString() + ".");
	    }
	    private static void OnGet (int senderId, byte[] data) {

		    BlitPacket recvPacket = new BlitPacket(data);

		    string userAgent = recvPacket.GetString();
		    string sender = recvPacket.GetString();

		    string contentId = recvPacket.GetString();

		    SendContentTo(senderId, contentId);

		    Logging.Log(userAgent + "::" + sender + "; Requested content: " + contentId + ".");
	    }

	    private static int SendContentTo (int targetId, string contentId) {

		    if (!File.Exists("cdn/" + contentId.Replace('/', '_')))
			    return -1;

		    BlitPacket contentPacket = new BlitPacket();
		    contentPacket.Append(contentId);
		    contentPacket.Append(File.ReadAllBytes("cdn/" + contentId.Replace('/', '_')));

		    Network.server.RelayTo(PacketId.SubmitContent, targetId, contentPacket.ToArray());

		    return 0;
	    }
	    private static int SaveContent (string contentId, byte[] data) {

		    File.WriteAllBytes("cdn/" + contentId.Replace('/', '_'), data);

		    return 0;
	    }
        }
    }
}
