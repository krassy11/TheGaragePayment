using System.Diagnostics;

namespace TheGarage.Services.Payment.client
{
    public class MessageLogger
    {
        public static void logMessage(string message)
        {

            Debug.WriteLine(message);
        }
        public static void logMessage(string message, string format)
        {
            string logMessage = string.Format("SecureRandom nonce:{0}", format);
            Debug.WriteLine(logMessage);
        }

        public static void debug(string message, string format)
        {
            string logMessage = string.Format("SecureRandom nonce:{0}", format);
            Debug.WriteLine(logMessage);
        }

        public static void info(string message, string format)
        {
            string logMessage = string.Format("SecureRandom nonce:{0}", format);
            Debug.WriteLine(logMessage);
        }

        public static void error(string message, string format)
        {
            string logMessage = string.Format("SecureRandom nonce:{0}", format);
            Debug.WriteLine(logMessage);
        }
    }

}

