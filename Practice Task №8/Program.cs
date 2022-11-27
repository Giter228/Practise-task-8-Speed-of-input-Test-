using System.Text;

namespace Practice_Task__8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                ScoreTable scoreTable = new ScoreTable();
                scoreTable.Name_Player();
            }
        }
    }        
}