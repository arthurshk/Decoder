using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    internal class Program
    {
        public static string decode(string message_file)
        {
            string fileName = message_file;
            Dictionary<int, string> dict = new Dictionary<int, string>();

            using (var streamreader = new StreamReader(fileName))
            {
                string line;
                while ((line = streamreader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int number = int.Parse(parts[0]);
                    string word = parts[1];
                    dict.Add(number, word);
                }
            }

            List<string> decodedWords = new List<string>();
            int level = 1;
            while (dict.ContainsKey(level))
            {
                decodedWords.Add(dict[level]);
                level++;
            }

            return string.Join(" ", decodedWords);
        }

        static void Main(string[] args)
        {
            string decodedMessage = decode("coding_qual_input.txt");
            Console.WriteLine(decodedMessage);
        }
    }
}