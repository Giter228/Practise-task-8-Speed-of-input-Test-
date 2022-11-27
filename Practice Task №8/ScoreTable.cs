using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Practice_Task__8
{
    public class ScoreTable
    {
        public static string name;
        public void Name_Player()
        {
            Console.WriteLine("Введите имя для таблицы рекордов:");
            name = Console.ReadLine();

            Console.Clear();
            
            Texts texts = new Texts();
            texts.GenerateText(name);
        }
        public void Speed_Results(int minute, double second)
        {
            User player = new User();


            player.Name = name;
            player.Per_Minute = minute;
            player.Per_Second = second;
            Console.ReadLine();

            List<User> list = new List<User>();
            list.Add(player);

            string json = JsonConvert.SerializeObject(list);
            string way = "C:\\Users\\Максим\\OneDrive\\Рабочий стол\\TableScore.json";
            File.AppendAllText(way, json);

            string table = File.ReadAllText(way);
            List<User> list2 = JsonConvert.DeserializeObject<List<User>>(table);

            Console.Clear();

            Console.Write("Таблица рекордов:\n-------------------\n");
            foreach (var item in list2)
            {
                Console.Write(item.Name + "; ");
                Console.Write(item.Per_Minute + " символов в минуту; ");
                Console.WriteLine(item.Per_Second + " символов в секунду");
            }

            
            
            Console.WriteLine("Нажмите Enter, чтобы начать тест ещё раз.");

            ConsoleKeyInfo key= Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true);
            }
            Console.Clear();
        }
    }
}
