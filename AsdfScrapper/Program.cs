using System;
using System.Collections.Generic;

namespace WebRequestTest
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter FULL path to textfile with usernames");

            /*
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("ascii.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
            */

            Console.WriteLine("Application start");

            BruteForce bruteForce = new BruteForce();
            bruteForce.Start(3);
            List<string> usernames = bruteForce.GetUsernames();
            MailApi mailApi = new MailApi();
            mailApi.SetTimeout(0);

            int recordNumber = 1;
            foreach (string username in usernames)
            {
                Message[] messages = mailApi.GetMessages(username);
                mailApi.Timeout();
                Console.WriteLine("{0} {1} {2}", recordNumber, username, messages.Length);
                recordNumber++;
            }

        }

    }

}
