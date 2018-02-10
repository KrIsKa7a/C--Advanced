using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.BasicMarkUpLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            var oneAttributeCommandPattern = @"\<\s*(?<cdmType>[A-Za-z]+)\s+(?<attribute>[A-Za-z]+)\s*\=\s*\""(?<attributeValue>[^\""]+)\""\s*\/\s*\>";
            var twoAttributeCommandPattern = @"\<\s*(?<cdmType>[A-Za-z]+)\s+(?<attribute>[A-Za-z]+)\s*\=\s*\""(?<attributeValue>[^\""]+)\""\s* (?<attribute2>[A-Za-z]+)\s*\=\s*\""(?<attributeValue2>[^\""]+)\""\s*\/\>";

            var outPut = new StringBuilder();
            var currentLine = 1;

            while (command != "<stop/>")
            {
                if (Regex.IsMatch(command, oneAttributeCommandPattern))
                {
                    var match = Regex.Match(command, oneAttributeCommandPattern);
                    var type = match.Groups["cdmType"].Value;
                    var toBeDone = match.Groups["attributeValue"].Value;

                    if (type == "inverse")
                    {
                        string inversedWord = InverseWord(toBeDone);
                        string readyOutput = GetOutputReady(inversedWord, currentLine);
                        outPut.AppendLine(readyOutput);
                        currentLine++;
                    }
                    else if (type == "reverse")
                    {
                        string reversedWord = ReverseWord(toBeDone);
                        string readyOutput = GetOutputReady(reversedWord, currentLine);
                        outPut.AppendLine(readyOutput);
                        currentLine++;
                    }
                }
                else if (Regex.IsMatch(command, twoAttributeCommandPattern))
                {
                    var match = Regex.Match(command, twoAttributeCommandPattern);
                    var count = int.Parse(match.Groups["attributeValue"].Value);
                    var word = match.Groups["attributeValue2"].Value;

                    for (int i = 0; i < count; i++)
                    {
                        string readyOutput = GetOutputReady(word, currentLine);
                        outPut.AppendLine(readyOutput);
                        currentLine++;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(outPut.ToString().TrimEnd());
        }

        private static string GetOutputReady(string word, int currentLine)
        {
            return $"{currentLine}. {word}";
        }

        private static string ReverseWord(string toBeDone)
        {
            var newWord = new StringBuilder();

            for (int i = toBeDone.Length - 1; i >= 0; i--)
            {
                var currentChar = toBeDone[i];
                newWord.Append(currentChar);
            }

            return newWord.ToString();
        }

        private static string InverseWord(string toBeDone)
        {
            var newWord = new StringBuilder();

            for (int i = 0; i < toBeDone.Length; i++)
            {
                var currentChar = toBeDone[i];

                if (char.IsLower(currentChar))
                {
                    newWord.Append(currentChar.ToString().ToUpper());
                }
                else if (char.IsUpper(currentChar))
                {
                    newWord.Append(currentChar.ToString().ToLower());
                }
                else
                {
                    newWord.Append(currentChar);
                }
            }

            return newWord.ToString();
        }
    }
}
