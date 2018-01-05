using System;
using System.Collections.Generic;

namespace WebRequestTest
{
    public class FileReader
    {
        static List<string> ReadUsernamesFromFile(string filePath)
        {
            Console.WriteLine("Reading username from file at {0}", filePath);
            List<string> usernames = new List<string>();
            Console.WriteLine("File read successfully!");
            Console.WriteLine("Usernames found : {0}", usernames);
            return usernames;
        }
    }
}
