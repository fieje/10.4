using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFindMaxWordInLine()
        {
            string line = "The quick brown fox jumps over the lazy dog";

            string maxWord = Program.FindMaxWordInLine(line);

            Assert.AreEqual("quick", maxWord);
        }

        [TestMethod]
        public void TestWriteMaxWordsToFile()
        {
            string outputFileName = "test_output.txt";
            List<string> maxWordsList = new List<string> { "jumped", "lazy", "elephant" };

            Program.WriteMaxWordsToFile(outputFileName, maxWordsList);

            Assert.IsTrue(File.Exists(outputFileName));

            File.Delete(outputFileName);
        }
    }

    public class Program
    {
        public static string FindMaxWordInLine(string line)
        {
            string[] words = line.Split(' ');
            string maxWord = "";

            foreach (string word in words)
            {
                if (word.Length > maxWord.Length)
                {
                    maxWord = word;
                }
            }

            return maxWord;
        }

        public static void WriteMaxWordsToFile(string outputFileName, List<string> maxWordsList)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    foreach (string word in maxWordsList)
                    {
                        writer.WriteLine(word);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
