using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MorseApp_API.Dtos;

namespace MorseApp_API.Logic
{
    public class MorseTranslator : ITranslator
    {
        private static readonly Dictionary<char, string> DecodeAlphabet = new Dictionary<char, string>()
            {
                {'a', ".-"},{'b', "-..."},{'c', "-.-."},{'d', "-.."},{'e', "."},{'f', "..-."},{'g', "--."}, {'h', "...."},{'i', ".."},
                {'j', ".---"},{'k', "-.-"},{'l', ".-.."},{'m', "--"},{'n', "-."},{'o', "---"},{'p', ".--."},{'q', "--.-"},{'r', ".-."},
                {'s', "..."},{'t', "-"},{'u', "..-"},{'v', "...-"},{'w', ".--"},{'x', "-..-"},{'y', "-.--"},{'z', "--.."},{'0', "-----"},
                {'1', ".----"},{'2', "..---"},{'3', "...--"},{'4', "....-"},{'5', "....."},{'6', "-...."},{'7', "--..."},{'8', "---.."},
                {'9', "----."},{' ', ""},{'/', "/"}
            };

        private static readonly Dictionary<string, char> EncodeAlphabet = new Dictionary<string, char>()
            {
                {".-", 'a'},{"-...", 'b'},{"-.-.", 'c'},{"-..", 'd'},{".", 'e'},{"..-.", 'f'},{"--.", 'g'}, {"....", 'h'},{"..", 'i'},
                {".---", 'j'},{"-.-", 'k'},{".-..", 'l'},{"--", 'm'},{"-.", 'n'},{"---", 'o'},{".--.", 'p'},{"--.-", 'q'},{".-.", 'r'},
                {"...", 's'},{"-", 't'},{"..-", 'u'},{"...-", 'v'},{".--", 'w'},{"-..-", 'x'},{"-.--", 'y'},{"--..", 'z'},{"-----", '0'},
                {".----", '1'},{"..---", '2'},{"...--", '3'},{"....-", '4'},{".....", '5'},{"-....", '6'},{"--...", '7'},{"---..", '8'},
                {"----.", '9'},{" ", ' '}
            };

        public string Decode(string message)
        {
            if (!message.All(c => Char.IsLetterOrDigit(c) || c == ' '))
            {
                throw new ArgumentException("Message contains invalid characters.");
            }
            message = message.ToLower();
            message = Regex.Replace(message, "(.)", "$1/").TrimEnd('/');

            message.Replace(" ", string.Empty);

            char[] messageArray = message.ToCharArray();
            var decodedMessage = "";
            string character;
            foreach (char c in messageArray)
            {

                DecodeAlphabet.TryGetValue(c, out character);
                decodedMessage += character;
            }
            return decodedMessage;
        }

        public string Encode(string message)
        {
            if (message.Length == 0)
            {
                return "";
            }
            var encodedMessage = "";

            if (!message.All(c => c == '/' || c == '.' || c == '-'))
            {
                throw new ArgumentException("Message contains unsupported characters.");
            }

            message = message.Replace("//", "// /");
            Console.WriteLine(message);

            string[] words = message.Split("//");
            foreach (string word in words)
            {
                string[] characters = word.Split('/');
                foreach (string character in characters)
                {
                    encodedMessage += EncodeAlphabet[character];
                }
            }
            return encodedMessage;
        }
    }
}