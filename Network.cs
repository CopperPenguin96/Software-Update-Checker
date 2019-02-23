using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Updater
{
    /// <summary>
    /// Various network utils used by the library
    /// </summary>
    internal class Network
    {
        /// <summary>
        /// Obtain source of webpage
        /// </summary>
        /// <param name="urlF">The url needed</param>
        /// <returns>source of page</returns>
        public static List<string> GetUrlSourceAsList(string urlF)
        {
            const string temp = "check_file.txt";
            var c = File.CreateText(temp);
            c.Close();
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(urlF, temp);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            try
            {
                return File.ReadAllLines(temp).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<string>();
            }
        }
    }
}
