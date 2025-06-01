// See https://aka.ms/new-console-template for more information
using System.Text;

namespace Classcreation
{
    public class MessageProcessor
    {
        public string Message{ get => message; set => message = value;}
        string message;
        byte[] code;
        public MessageProcessor(string a)
        {
            message = a;
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
            /*string[] words = message.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    string m = new string('*', count);
                    words[i] = m;
                }
            }
            return string.Join(" ", words);
            */
            return message.Replace(word, new string('*', count));
        }
        public void Display()
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Write ur message");
            MessageProcessor M1 = new MessageProcessor(Console.ReadLine());
            M1.Display();
            Console.WriteLine("Update ur message");
            M1.Message = Console.ReadLine();
            M1.Display();
            Console.WriteLine("Find word in ur message");
            bool chek = M1.ContainsWord(Console.ReadLine());
            if (chek == true)
            {
                Console.WriteLine("Word is founded");
            }
            else
            {
                Console.WriteLine("Word is not founded");
            }
            
            string m = M1.GetCapitalizedMessage();
            Console.WriteLine("capitalized message: {0}", m);
            M1.EncryptMessage();
            M1.Display();
            M1.DecryptMessage();
            M1.Display();
            Console.WriteLine("Enter the hiden word: ");
            string hide = M1.HideWord(Console.ReadLine());
            Console.WriteLine("Hided message: {0}", hide);

            
        }
    }
}
