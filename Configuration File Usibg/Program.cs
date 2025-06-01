// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Classcreation;
using System.Text;

namespace Classcreation
{
    public class MessageProcessor
    {
        public string Message { get => message; set => message = value; }
        string message;
        byte[] code;
        public MessageProcessor(string a)
        {
            message = a;
        }
        public MessageProcessor()
        {
            message = "";
        }
        public string GetMessage()
        {
            return message;
        }
        public void UpdateMessage(string newMessage)
        {
            message = newMessage;
        }
        public bool ContainsWord(string word)
        {
            string[] words = message.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetCapitalizedMessage()
        {
            return message.ToUpper();
        }
        public void EncryptMessage()
        {
            code = Encoding.UTF8.GetBytes(message);
            message = string.Join("", code);
        }
        public void DecryptMessage()
        {
            message = Encoding.UTF8.GetString(code);
        }
        public string HideWord(string word)
        {
            int count = word.Length;
            return message.Replace(word, new string('*', count));
        }
        public void Display()
        {
            Console.WriteLine(message);
        }
    }
    public class MessageConfig
    {
        public Dictionary<string,string> Operations { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            logger.Log("Програма запущена");
            string jsonfile = File.ReadAllText("config.json");
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonfile);
            MessageProcessor M1 = new MessageProcessor();
            Userinfo writer = new Userinfo("userinfo.txt");
            writer.WritingUserInfo();
            string info = writer.ReaderInfo();
            logger.WriteLine("Введіть значення message :");
            M1.UpdateMessage(info);
            while (true)
            {
                if (string.IsNullOrEmpty(M1.Message))
                {
                    logger.WriteLine("Введіть значення message :");
                    M1.UpdateMessage(Console.ReadLine());
                    continue;
                }

                logger.WriteLine("Оберіть метод:\n 1.Вивести значення message {0}\n 2.Оновити значення message {1}\n 3.Перевірити наявність слова в message {2}\n 4.Зробити всі літери в message великими {3}\n 5.Зашифрувати значення message {4}\n 6.Розшифрувати значення message {5}\n 7.Приховати слово в значенні message {6}", config["Display"], config["UpdateMethod"], config["ContainsWord"], config["GetCapitalizedMessage"], config["EncryptMessage"], config["DecryptMessage"], config["HideWord"]);
                string n = Console.ReadLine();
                if (n == "stop")
                {
                    break;
                }
                if (n == config["UpdateMethod"])
                {
                    logger.WriteLine("Оновіть значення message :");
                    M1.UpdateMessage(logger.ReadLine());
                }
                else if (n == config["ContainsWord"])
                {
                    logger.WriteLine("Введіть слово для перевірки: ");
                    bool chek = M1.ContainsWord(logger.ReadLine());
                    if (chek == true)
                    {
                        logger.WriteLine("Word is founded");
                    }
                    else
                    {
                        logger.WriteLine("Word is not founded");
                    }
                }
                else if (n == config["GetCapitalizedMessage"])
                {
                    string m = M1.GetCapitalizedMessage();
                    logger.WriteLine("Літери зроблені великими: {0}", m);
                }
                else if (n == config["EncryptMessage"])
                {
                    M1.EncryptMessage();
                    logger.WriteLine("Повідомлення було зашифровано.");
                }
                else if (n == config["DecryptMessage"])
                {
                    M1.DecryptMessage();
                    logger.WriteLine("Повідомлення було розшифровано.");
                }
                else if (n == config["HideWord"])
                {
                    logger.WriteLine("Введіть слово яке потрібно приховати");
                    string hide = M1.HideWord(logger.ReadLine());
                    logger.WriteLine(hide);
                }
                else if (n == config["Display"])
                {
                    logger.WriteLine("Ваше повідомлення: ");
                    M1.Display();
                }
            }
        }
    }
}
