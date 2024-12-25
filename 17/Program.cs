using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _17
{
    internal class Program
    {
        static void zadacha1()
        {
            //9.	Дан текст. Некоторые его фрагменты выделены группами символов ##.
            //Заменить выделение группами символов '<' и '>)'.
            //Пример: 'Это ##тестовый пример## для задачи ##на## строки' преобразуется в 'Это <тестовый> пример для задачи <на> строки'

            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            // Используем регулярное выражение для замены ##...## на <...>
            string result = Regex.Replace(text, "##(.*?)##", "<$1>");

            // Выводим результат
            Console.WriteLine("Преобразованный текст:");
            Console.WriteLine(result);
        }


        static void zadacha2()
        {
            //40.	В заданном предложении найти пару слов, из которых одно является обращением другого
            //(обращение – слово, получающееся из исходного записью его букв в обратном порядке).
            // Вводим предложение
            Console.Write("Введите предложение: ");
            string sentence = Console.ReadLine();

            // Разбиваем предложение на слова, удаляя лишние пробелы и знаки препинания
            string[] words = sentence.Split(new[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            bool found = false; // Флаг, который указывает, что пара найдена

            // Ищем пару слов, одно из которых является обращением другого
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    // Переворачиваем второе слово
                    char[] reversed = words[j].ToCharArray();
                    Array.Reverse(reversed);
                    string reversedWord = new string(reversed);

                    // Проверяем, является ли одно слово обращением другого
                    if (words[i] == reversedWord)
                    {
                        Console.WriteLine($"Найдена пара: '{words[i]}' и '{words[j]}'");
                        found = true;
                    }
                }
            }

            // Если пара не найдена, выводим соответствующее сообщение
            if (!found)
            {
                Console.WriteLine("Пары слов, являющихся обращениями друг друга, не найдены.");
            }

        }


        static string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЭЮЯ";

        static void zadacha3()
        {
            // Шифрованный текст
            string cipherText = "В И О Ь Х Ь З Ж У Ш Ц Ш М Ь Г Р О Ш К Ь Э З Д О Е Ж Ы Р О Р Л Й Я О Ш К";

            // Слово для расшифровки
            string wordToDecrypt = "ШИФРАТОР";

            // Разбиваем шифрованный текст на слова
            string[] cipherWords = cipherText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Перебираем все возможные фрагменты шифртекста
            foreach (var word in cipherWords)
            {
                // Проверяем, соответствует ли этот фрагмент слову ШИФРАТОР
                if (word.Length == wordToDecrypt.Length)
                {
                    // Симулируем диск Альберти
                    for (int shift = 0; shift < alphabet.Length; shift++)
                    {
                        bool match = true;

                        // Проверяем, подходит ли текущее слово с сдвигом
                        for (int i = 0; i < word.Length; i++)
                        {
                            // Индексы букв в алфавите
                            int originalIndex = alphabet.IndexOf(wordToDecrypt[i]);
                            int cipherIndex = (alphabet.IndexOf(word[i]) - shift + alphabet.Length) % alphabet.Length;

                            if (originalIndex != cipherIndex)
                            {
                                match = false;
                                break;
                            }
                        }

                        if (match)
                        {
                            // Если нашли совпадение, выводим результат
                            Console.WriteLine($"Соответствующий фрагмент шифртекста для слова '{wordToDecrypt}': {word}");
                            return;
                        }
                    }
                }
            }

            // Если не нашли совпадений
            Console.WriteLine("Не найдено соответствий.");
        }
    


        static void Main(string[] args)
        {
            //9 40 68
            Console.Write("Введите номер задачи:");
                byte numb = byte.Parse(Console.ReadLine());
            switch (numb)
            {
                case 1:zadacha1();break;
                case 2: zadacha2(); break;
                case 3: zadacha3(); break;

            }
        }
    }
}

