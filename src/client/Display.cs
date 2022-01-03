
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tolt {

    namespace Client {

        public static class Display {

    		private static List<string> messageList = new List<string>();

    		public static void Append (string sender, string message) {

    			messageList.Add("[" + sender + "]: " + message);
            }
    		public static void Append (string message) {

    			messageList.Add(message);
    		}

    		public static void Tick () {

    			RunChecks();
    		}

    		private static int messageListCache;
    		private static int consoleHeightCache, consoleWidthCache;
    		private static string inputCache;

    		private static void RunChecks () {

    			if (messageListCache != messageList.Count) {

    				messageListCache = messageList.Count;
    				Render();
    			}

    			if (consoleHeightCache != Console.BufferHeight) {

    				consoleHeightCache = Console.BufferHeight;
    				Render();
    			}

    			if (consoleWidthCache != Console.BufferWidth) {

    				consoleWidthCache = Console.BufferWidth;
    				Render();
    			}

    			if (inputCache != Input.inputValue) {

    				inputCache = Input.inputValue;
    				Render();
    			}

    		}

    		private static void Render () {

    			Console.Clear();

    			foreach (string message in messageList)
    				Console.WriteLine(message);

    			if (messageList.Count < Console.BufferHeight)
    				for (int i = 2; i < Console.BufferHeight - messageList.Count; ++i)
    					Console.WriteLine();

    			for (int i = 0; i < Console.BufferWidth; ++i)
    				Console.Write("─");

    			Console.Write(">: " + inputCache);
    		}
        }
    }
}
