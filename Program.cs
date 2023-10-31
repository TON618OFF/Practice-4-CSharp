using Practice_4_Notes;
using System.Globalization;
using System.Text;
using static System.Console;
namespace Practice_4
{
    internal class Program
    {
        static DateTime currentDate = DateTime.Today;
        static int minPosition = 1;
        static int maxPosition = 3;
        static int currentPosition = 1;
        static bool Work = true;
        static List<Notes> notes = new List<Notes>();
        static void Main()
        {
            notes.Add(new Notes("ВЫХОД СОЛЬНИКА ОЛЕГА!!!", "АЛЬБИК В МОЮ ДНЮХУ, ДЕТКА!", new DateTime(2022, 7, 1)));
            notes.Add(new Notes("ДР Сестры", "Поздравить с др свою сестру", new DateTime(2022, 7, 5)));
            notes.Add(new Notes("Поехать на треню", "ФУТБИК НЕ ЖДЁТ", new DateTime(2022, 7, 10)));
            notes.Add(new Notes("Время Денег", "Отослать заказные биточки", new DateTime(2022, 7, 13)));
            notes.Add(new Notes("ЛЕНЬ", "Сидеть дома и смотреть губку боба", new DateTime(2022, 7, 18)));
            notes.Add(new Notes("Грусть...", "Месяц до учёбы(((", new DateTime(2022, 8, 1)));

            CursorVisible = false;
            Menu();
        }


        static void Menu()
        {
            ConsoleKey key;
            while (Work)
            {
                Clear();
                WriteLine($"Выбранная дата: {currentDate:dd.MM.yyyy}");
                WriteLine("  1. Создать заметку на выбранную дату.");
                WriteLine("  2. Вывести список заметок.");
                WriteLine("  3. Закрыть программу.");

                CursorWrite();
                key = ReadKey().Key;

                if (key == ConsoleKey.RightArrow) Controls(1);
                if (key == ConsoleKey.LeftArrow) Controls(2);
                if (key == ConsoleKey.DownArrow) Controls(3);
                if (key == ConsoleKey.UpArrow) Controls(4);
                if (key == ConsoleKey.Enter) Controls(5);
            }
        }


        static void Controls(int control)
        {
            switch (control)
            {
                case 1:
                    currentDate = currentDate.AddDays(1);
                    break;
                case 2:
                    currentDate = currentDate.AddDays(-1);
                    break;
                case 3:
                    Arrow(true);
                    break;
                case 4:
                    Arrow(false);
                    break;
                case 5:
                    if (currentPosition == 1)
                    {
                        AddNote();
                    }
                    if (currentPosition == 2)
                    {
                        CheckNotes();
                    }
                    if (currentPosition == 3)
                    {
                        Work = false;
                    }
                    break;
            }
        }

        private static void CheckNotes()
        {
            Clear();
            foreach (var notes in notes)
            {
                if (notes.Date == currentDate)
                {
                    WriteLine($"Название заметки: {notes.Name}\r\n" +
                    $"Содержание заметки: {notes.Description}");
                }
            }
            ReadKey();
        }

        private static void AddNote()
        {
            Clear();
            Console.WriteLine("Введите название заметки: ");
            var name = ReadLine();
            Console.WriteLine("Введите содержание заметки: ");
            var desk = ReadLine();
            notes.Add(new Notes(name, desk, currentDate));
        }

        private static void Arrow(bool side)
        {
            if (side)
            {
                currentPosition++;
                if (currentPosition > maxPosition)
                {
                    currentPosition--;
                }
            }
            else
            {
                currentPosition--;
                if (currentPosition < minPosition)
                {
                    currentPosition++;
                }
            }
        }

        private static void CursorWrite()
        {
            SetCursorPosition(0, currentPosition);
            WriteLine("->");
        }
    }
}
