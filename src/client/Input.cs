
using System;
using System.Threading;

namespace Tolt {

    namespace Client {

    	public static class Input {

    		private static Mutex mutex = new Mutex();

    		public static string inputValue {

    			get {

    				string returnValue;

    				mutex.WaitOne(); try {

    					returnValue = __inputValue;

    				} finally { mutex.ReleaseMutex(); }

    				return returnValue;
    			}
    			set {

    				mutex.WaitOne(); try {

    					__inputValue = value;

    				} finally { mutex.ReleaseMutex(); }
    			}
    		}

    		private static string __inputValue;

    		private static Thread inputThread;

    		public static void Start () {

    			inputThread = new Thread(()=>Loop());
    			inputThread.Start();
    		}
    		public static void Stop () {

    			inputThread.Abort();
    		}

    		private static void Fire () {

    			if (inputValue.Length == 0) return;

    			// if (inputValue[0] == '/') Command.Feed(inputValue);
                // else Cache.queuedMessages.Add(inputValue);

                Messenger.SendMessage(inputValue);

    			inputValue = "";
    		}

    		private static void Loop () {

    			while (true) {

    				ConsoleKeyInfo cki = Console.ReadKey(true);

    				if (cki.Key == ConsoleKey.Backspace && inputValue.Length > 0)
    					inputValue = inputValue.Remove(inputValue.Length - 1);
    				else if (cki.Key == ConsoleKey.Enter)
    					Fire();
    				else if (cki.Key == ConsoleKey.Escape)
    					Environment.Exit(0);
    				else
    					inputValue += cki.KeyChar.ToString();
    			}
    		}
    	}
    }
}
