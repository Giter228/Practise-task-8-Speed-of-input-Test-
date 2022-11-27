using System;
using System.Diagnostics;
using System.Threading;

namespace Practice_Task__8
{
    public class Texts
    {
        private string text, time;
        public void GenerateText(string name)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 4);

            if (value == 0)
            {
                text = @"Она была молода и хороша собой. Большие выразительные глаза, изящные ножки, спокойный и трудолюбивый характер. Вот только есть недостаток - с раннего утра и до заката солнца вся в работе. Одно приятно, что занятие ее поистине женское и связано с цветами. Но работа есть работа, даже, если  любимая. Легко себе представить, что никакой личной жизни у нее не было, коллектив ведь исключительно женский. Умотаешься за день, к вечеру так устанешь, что летишь сломя голову домой без задних ног и сразу спать. О спутнике жизни она даже и не мечтала! Скажете, такого не может быть? Вполне может, если наша цветочница – настоящая пчела.";
            }
            else if (value == 1)
            {
                text = @"С раннего утра он тщательно побрился, начистил ботинки, надел выглаженную рубашку и костюм, который несколько лет назад она выбрала для него. Он всегда ценил её вкус, поэтому по торжественным случаям надевал именно этот костюм. Из дома вышел налегке. По дороге купил ее любимые цветы: белые хризантемы. Он всегда дарил ей белые хризантемы, а она всегда восхищалась этими цветами. Не спеша шел по аллее с букетом. Он всегда немного волновался, когда шел к ней. И вот место встречи. С фотографии надгробной плиты на него смотрела немолодая, но ещё очень красивая женщина, его жена. ""Милая, здравствуй! Я принес тебе твои любимые цветы""";
            }
            else if (value == 2)
            {
                text = @"Сколько же можно пялиться на меня своими бесстыдными глазами?! Каждый день работать в таком напряжении просто невозможно! Похоже, он опять замышляет, как унизить меня при всех. И главное, управы на этого мажора никакой. Над ним ""крыша"". Стараюсь отключить навязчивые мысли о неминуемом позоре, но автоматически жду подвоха, что ужасно отвлекает от работы. - Что Вам нужно, Указкин? Спрашиваю я у зависшего надо мной мучителя и отравы жизни моей. - Отец Вас к себе вызывает - ехидно улыбается он. Стою тоскливо под дверью, как провинившаяся школьница. Табличка на двери гласит: Директор школы Указкин Дмитрий Алексеевич. Никому не пожелаю быть классной руководительницей у директорского сына..";
            }
            else if (value == 3)
            {
                text = @"Так бережно разливается по воздуху звук торопливого ручейка, весело бегущего извилистой ленточкой среди травы. Словно играя на арфе, падают росинки с деревьев, перепрыгивают еле слышно на цветы, а потом беззвучно исчезают в траве. На  поляне жужжат деловые шмели, саранча поет свою незамысловатую песню. То здесь, то там слышно щебетанье птиц. А тон всему задает тихий шелест ветра. Словно дирижер он руководит журчанием ручья, следит за тональностью росинок и периодически утихомиривает насекомых. Лида лежит на мягкой траве, прикрывая голову от солнца большим листом лопуха, и наслаждается музыкой природы. Она ничего не может слышать уже несколько лет. Ей помогает в этом память.";
            }

            char[] chars = text.ToCharArray();

            foreach (char id in chars)
            {
                Console.Write(id);
            }
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Нажмите ENTER, чтобы начать печатать:");

            ConsoleKeyInfo HotKey = Console.ReadKey(true);
            while (HotKey.Key != ConsoleKey.Enter)
            {
                HotKey = Console.ReadKey(true);
            }

            Thread thread = new Thread(_ =>
            {
                Stopwatch go = new Stopwatch();

                Console.CursorVisible = false;
                go.Start();
                time = "";
                while ("00:00" != time)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(50, 10);
                    Console.WriteLine("Timer: 1:00");
                    Thread.Sleep(1000);
                    for (int i = 0; i < 59; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (i >= 30)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        if (i >= 49)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        TimeSpan timeSpan = go.Elapsed;
                        time = String.Format("{0:00}:{1:00}",
                            timeSpan.Minutes, 60 - timeSpan.Seconds);
                        Console.SetCursorPosition(50, 10);
                        Console.Write("Timer: "+ time + "");
                        Thread.Sleep(1000);
                    }
                    go.Stop();
                    time = "00:00";
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(50, 10);
                Console.WriteLine("Стоп!           ");
                Console.SetCursorPosition(47, 11);
                Console.WriteLine("-----------");
            });
            thread.Start();

            Console.SetCursorPosition(0, 0);

            int mistakes = 0;
            int amountOFSymbols = 0;

            int length = 0;
            int width = 0;
            for (int index = 0; index < chars.Count(); index++)
            {
                
                if (time == "00:00")
                {
                    break;
                }

                ConsoleKeyInfo item = Console.ReadKey();

                while (item.KeyChar != chars[index])
                {
                    Console.SetCursorPosition(length, width);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(chars[index]);
                    Console.SetCursorPosition(length, width);
                    if (time == "00:00")
                    {
                        break;
                    }
                    mistakes++;
                    item = Console.ReadKey();
                    while (item.KeyChar != chars[index])
                    {
                        mistakes = mistakes;
                        item = Console.ReadKey();
                    }
                }

                if (item.KeyChar == chars[index])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(length, width);
                    Console.Write(item.KeyChar);
                    amountOFSymbols++;
                }
                length++;
                if (length >= Console.BufferWidth)
                {
                    length = 0;
                    width++;
                    Console.SetCursorPosition(length, width);
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Вы выиграли!");
            Console.WriteLine("Количество совершённых ошибок - " + mistakes);
            Console.WriteLine("Количество введённых сиволов - " + amountOFSymbols);
            Console.ReadLine();

            var words = amountOFSymbols / 5;
            int minute = words - mistakes;
            double second =(double) minute / 60;
            second = Math.Round(second, 3);

            ScoreTable result = new ScoreTable();
            result.Speed_Results(minute, second);
        }
    }
}
